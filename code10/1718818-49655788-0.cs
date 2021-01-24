    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    private void SaveControlAsImage(Control control, string path)
    {
        Bitmap bitmap = new Bitmap(control.Width, control.Height);
        control.DrawToBitmap(bitmap, control.Bounds);
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
        {
            /* using ImageFormat.Png or ImageFormat.Bmp saves the image with better quality */
            bitmap.Save(fs, ImageFormat.Png);
        }
    }
