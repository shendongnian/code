    System.Drawing.Bitmap bmpOut = new System.Drawing.Bitmap(NewWidth, NewHeight);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmpOut);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.FillRectangle(System.Drawing.Brushes.White, 0, 0, NewWidth, NewHeight);
        g.DrawImage(new System.Drawing.Bitmap(fupProduct.PostedFile.InputStream), 0, 0, NewWidth, NewHeight);
        MemoryStream stream = new MemoryStream();
        switch (fupProduct.FileName.Substring(fupProduct.FileName.IndexOf('.') + 1).ToLower())
        {
            case "jpg":
                bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                break;
            case "jpeg":
                bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                break;
            case "tiff":
                bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Tiff);
                break;
            case "png":
                bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                break;
            case "gif":
                bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
                break;
        }
        String saveImagePath = Server.MapPath("../") + "Images/Thumbnail/" + fupProduct.FileName.Substring(fupProduct.FileName.IndexOf('.'));
        bmpOut.Save(saveImagePath);
