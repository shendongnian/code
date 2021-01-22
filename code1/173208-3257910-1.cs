    Bitmap bmpIcon = icon.ToBitmap();
          
    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
    {
        bmpIcon.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);        
        return ms.ToArray();
    }
