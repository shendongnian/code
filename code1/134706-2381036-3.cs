    using Microsoft.VisualBasic.PowerPacks;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace LineShapeTest
    {
        /// 
        /// Test Form
        /// 
        public class Form1 : Form
        {
            IconLineShape myLine = new IconLineShape();
            ShapeContainer shapeContainer1 = new ShapeContainer();
            Panel panel1 = new Panel();
    
            public Form1()
            {
                this.panel1.Dock = DockStyle.Fill;
                // load your back image here
                //this.panel1.BackgroundImage =
                //global::WindowsApplication22.Properties.Resources._13820t;
                this.panel1.BackColor = Color.White;
                this.panel1.Controls.Add(shapeContainer1);
    
                this.myLine.StartPoint = new Point(20, 30);
                this.myLine.EndPoint = new Point(80, 120);
                this.myLine.Parent = this.shapeContainer1;
    
                MouseEventHandler panelMouseMove =
                    new MouseEventHandler(this.panel1_MouseMove);
                this.panel1.MouseMove += panelMouseMove;
                this.shapeContainer1.MouseMove += panelMouseMove;
    
                this.Controls.Add(panel1);
            }
    
            private void panel1_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    myLine.StartPoint = e.Location;
                }
            }
        }
    
        /// 
        /// Test LineShape
        /// 
        public class IconLineShape : LineShape
        {
            Icon myIcon = SystemIcons.Exclamation;
            PictureBox pictureBox = new PictureBox();
    
            public IconLineShape()
            {
                pictureBox.Image = Bitmap.FromHicon(myIcon.Handle);
                pictureBox.Size = myIcon.Size;
                pictureBox.Visible = true;
            }
    
            protected override void OnMove(System.EventArgs e)
            {
                base.OnMove(e);
                pictureBox.Location = this.StartPoint;
            }
    
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                base.OnPaint(e);
                pictureBox.Invalidate();
            }
    
            public override bool HitTest(int x, int y)
            {            
                return base.HitTest(x, y) |
                    pictureBox.RectangleToScreen(
                        pictureBox.DisplayRectangle).Contains(new Point(x, y));
            }
    
            protected override void OnParentChanged(System.EventArgs e)
            {
                // Parent is a ShapeContainer
                // Parent.Parent is a Panel
                pictureBox.Parent = Parent.Parent;
                base.OnParentChanged(e);
            }
        }
    }
