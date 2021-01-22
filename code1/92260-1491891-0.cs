    // Create new Bitmap at new dimensions
    Bitmap result = new Bitmap((int)newWidth, (int)newHeight);
    using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
       g.DrawImage(src, 0, 0, (int)newWidth, (int)newHeight);
    return result;
