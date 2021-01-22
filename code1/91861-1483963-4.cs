    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace FormTest
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            static extern bool GetCursorPos(ref Point lpPoint);
    
            [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
            public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
            
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
                using (Graphics gdest = Graphics.FromImage(screenPixel))
                {
                    using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                    {
                        IntPtr hSrcDC = gsrc.GetHdc();
                        IntPtr hDC = gdest.GetHdc();
                        int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                        gdest.ReleaseHdc();
                        gsrc.ReleaseHdc();
                    }
                }
    
                return screenPixel.GetPixel(0, 0);
            }
        }
    }
