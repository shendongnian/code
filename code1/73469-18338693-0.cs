    //Author: George Birbilis (http://zoomicon.com)
    //Version: 20130820
    
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WebCapture
    {
      public static class ScreenshotUtils
      {
    
        public static Rectangle Offseted(this Rectangle r, Point p)
        {
          r.Offset(p);
          return r;
        }
    
        public static Bitmap getScreenshot(this Control c)
        {
          return getScreenshot(new Rectangle(c.PointToScreen(Point.Empty), c.Size));
        }
    
        public static Bitmap getScreenshot(Rectangle bounds)
        {
          Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
          using (Graphics g = Graphics.FromImage(bitmap))
            g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
          return bitmap;
        }
    
      }
    }
