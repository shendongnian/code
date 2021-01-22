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
                this.BackColor = GetColorAtCursor();
            }
    
            public Color GetColorAtCursor()
            {
                Point cursor = new Point();
                GetCursorPos(ref cursor);
    
                var screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
    
                var g = Graphics.FromImage(screenPixel);
    
                g.CopyFromScreen(cursor.X, cursor.Y, 0, 0, new Size(1, 1));
    
                return screenPixel.GetPixel(0, 0);
            }
        }
    }
