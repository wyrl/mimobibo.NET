using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mimobibo
{
    public partial class Draggable : Component
    {
        private bool mouseDown = false;
        private Point lastLocation;

        public Draggable()
        {
            InitializeComponent();

        }

        public Draggable(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public Control TargetControl
        {
            get;
            set;
        }

        public Form WindowForm
        {
            get;
            set;
        }

        private void TargetControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TargetControl_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TargetControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (WindowForm != null)
                {
                    WindowForm.Location = new Point((WindowForm.Location.X - lastLocation.X) + e.X,
                        WindowForm.Location.Y - lastLocation.Y + e.Y);

                    WindowForm.Update();
                }
            }
        }

        public void Start()
        {
            if (TargetControl != null)
            {
                TargetControl.MouseDown += TargetControl_MouseDown;
                TargetControl.MouseUp += TargetControl_MouseUp;
                TargetControl.MouseMove += TargetControl_MouseMove;
            }
        }
    }
}
