    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsApplication1 {
      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) {
          Size sz = Screen.PrimaryScreen.Bounds.Size;
          IntPtr hDesk = GetDesktopWindow();
          IntPtr hSrce = GetWindowDC(hDesk);
          IntPtr hDest = CreateCompatibleDC(hSrce);
          IntPtr hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
          IntPtr hOldBmp = SelectObject(hDest, hBmp);
          bool b = BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, 0, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
          Bitmap bmp = Bitmap.FromHbitmap(hBmp);
          SelectObject(hDest, hOldBmp);
          DeleteObject(hBmp);
          DeleteDC(hDest);
          ReleaseDC(hDesk, hSrce);
          bmp.Save(@"c:\temp\test.png");
          bmp.Dispose();
        }
    
        // P/Invoke declarations
        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int
        wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);
      }
    }
