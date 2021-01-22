    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsForms_MouseEvents
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                MouseMove += OnMouseMove;
                MouseLeave += OnMouseLeave;
    
                HookMouseMove(this.Controls);
            }
    
            private void HookMouseMove(Control.ControlCollection ctls)
            {
                foreach (Control ctl in ctls)
                {
                    ctl.MouseMove += OnMouseMove;
                    HookMouseMove(ctl.Controls);
                }
            }
    
            private void OnMouseMove(object sender, MouseEventArgs e)
            {
                BackColor = Color.Plum;
    
                Control ctl = sender as Control;
                if (ctl != null)
                {
                    // Map mouse coordinate to form
                    Point loc = this.PointToClient(ctl.PointToScreen(e.Location));
                    Console.WriteLine("Mouse at {0},{1}", loc.X, loc.Y);
                }
            }
    
            private void OnMouseLeave(object sender, EventArgs e)
            {
                BackColor = Color.Gray;
            }
    
        }
    }
