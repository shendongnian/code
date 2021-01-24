    Bitmap finalImage = new Bitmap(speedometer);
    using (Graphics graphics = Graphics.FromImage(finalImage))
    {
        // ... stuff
    }
    using (MemoryStream ms = new MemoryStream())
    {
        finalImage.Save(ms, ImageFormat.Png);
        // This is important: otherwise anything reading the stream
        // will start at the point AFTER the written image.
        ms.Position = 0;
        Bot.SendPhotoAsync(/* send 'ms' here. Whatever the exact args are */);
    }
