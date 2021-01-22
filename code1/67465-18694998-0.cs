    byte[] bts = (byte[])page1.EnhMetaFileBits; 
    using (var ms = new MemoryStream(bts)) 
    { 
        var image = System.Drawing.Image.FromStream(ms); 
        System.Drawing.Image img = image.GetThumbnailImage(200, 260, null, IntPtr.Zero);      
        img.Save(NewPath, System.Drawing.Imaging.ImageFormat.Png);
    }
