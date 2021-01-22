    //Project: WebCapture
    //Filename: ScreenshotUtils.cs
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
    
        public static Bitmap GetScreenshot(this Control c)
        {
          return GetScreenshot(new Rectangle(c.PointToScreen(Point.Empty), c.Size));
        }
    
        public static Bitmap GetScreenshot(Rectangle bounds)
        {
          Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
          using (Graphics g = Graphics.FromImage(bitmap))
            g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
          return bitmap;
        }
        public const string DEFAULT_IMAGESAVEFILEDIALOG_TITLE = "Save image";
        public const string DEFAULT_IMAGESAVEFILEDIALOG_FILTER = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|GIF Image (*.gif)|*.gif|TIFF Image (*.tiff;*.tif)|*.tiff;*.tif";
        public const string CUSTOMPLACES_COMPUTER = "0AC0837C-BBF8-452A-850D-79D08E667CA7";
        public const string CUSTOMPLACES_DESKTOP = "B4BFCC3A-DB2C-424C-B029-7FE99A87C641";
        public const string CUSTOMPLACES_DOCUMENTS = "FDD39AD0-238F-46AF-ADB4-6C85480369C7";
        public const string CUSTOMPLACES_PICTURES = "33E28130-4E1E-4676-835A-98395C3BC3BB";
        public const string CUSTOMPLACES_PUBLICPICTURES = "B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5";
        public const string CUSTOMPLACES_RECENT = "AE50C081-EBD2-438A-8655-8A092E34987A";
    
        public static SaveFileDialog GetImageSaveFileDialog(
          string title = DEFAULT_IMAGESAVEFILEDIALOG_TITLE, 
          string filter = DEFAULT_IMAGESAVEFILEDIALOG_FILTER)
        {
          SaveFileDialog dialog = new SaveFileDialog();
          dialog.Title = title;
          dialog.Filter = filter;
          /* //this seems to throw error on Windows Server 2008 R2, must be for Windows Vista only
          dialog.CustomPlaces.Add(CUSTOMPLACES_COMPUTER);
          dialog.CustomPlaces.Add(CUSTOMPLACES_DESKTOP);
          dialog.CustomPlaces.Add(CUSTOMPLACES_DOCUMENTS);
          dialog.CustomPlaces.Add(CUSTOMPLACES_PICTURES);
          dialog.CustomPlaces.Add(CUSTOMPLACES_PUBLICPICTURES);
          dialog.CustomPlaces.Add(CUSTOMPLACES_RECENT);
          */
          return dialog;
        }
        public static void ShowSaveFileDialog(this Image image, IWin32Window owner = null)
        {
          using (SaveFileDialog dlg = GetImageSaveFileDialog())
            if (dlg.ShowDialog(owner) == DialogResult.OK)
              image.Save(dlg.FileName);
        }
    
      }
    }
