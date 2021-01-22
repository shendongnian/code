    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    using System.Runtime.InteropServices;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        Thread t;
        int x, y;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            x = 20;
            y = 50;
            t = new Thread(update);
            t.Start();
        }
        private void update()
        {
            Bitmap screenCopy = new Bitmap(1, 1);
            using (Graphics gdest = Graphics.FromImage(screenCopy))
            {
                while (true)
                {
                    //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(256, 256));
                    using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                    {
                        IntPtr hSrcDC = gsrc.GetHdc();
                        IntPtr hDC = gdest.GetHdc();
                        int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, x, y, (int)CopyPixelOperation.SourceCopy);
                        gdest.ReleaseHdc();
                        gsrc.ReleaseHdc();
                    }
                    Color c = Color.FromArgb(screenCopy.GetPixel(0, 0).ToArgb());
                    label1.ForeColor = c;
                }
            }
        }
    }
