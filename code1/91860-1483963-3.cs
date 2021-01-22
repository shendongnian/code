    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace FormTest
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            static extern bool GetCursorPos(ref Point lpPoint);
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void MouseMoveTimer_Tick(object sender, EventArgs e)
            {
                Point cursor = new Point();
                GetCursorPos(ref cursor);
    
                var c = GetColorAt(cursor);
                this.BackColor = c;
    
                if (c.R == 0 && c.G == 0 && c.B == 255)
                {
                    MessageBox.Show("Blue");
                }
            }
    
            Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            public Color GetColorAt(Point location)
            {
                var g = Graphics.FromImage(screenPixel);
                g.CopyFromScreen(location.X, location.Y, 0, 0, new Size(1, 1));
                return screenPixel.GetPixel(0, 0);
            }
        }
    }
