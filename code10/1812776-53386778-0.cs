    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace LevelEditor
    {
        class Platform : PictureBox
        {
    
            public Platform(int width, int height, int x, int y)
            {
                this.Width = width;
                this.Height = height;
                this.Location = new Point(x, y);
                this.BackColor = Color.Red;
                this.BorderStyle = BorderStyle.FixedSingle;
            }
    
            public void drawTo(Form form)
            {
                form.Controls.Add(this);
            }
    
            public void setPosition(int x, int y)
            {
                this.Location = new Point(x, y);
            }
    
            private Point MouseDownLocation;
    
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (e.Button == MouseButtons.Left)
                {
                    MouseDownLocation = e.Location;
                }
            }
    
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
    
                if (e.Button == MouseButtons.Left)
                {
                    this.Left = e.X + this.Left - MouseDownLocation.X;
                    this.Top = e.Y + this.Top - MouseDownLocation.Y;
                }
            }
        }
    }
