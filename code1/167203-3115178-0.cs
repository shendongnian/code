    System.Drawing.Bitmap TempBitmap = Image;
    System.Drawing.Bitmap NewBitmap = new System.Drawing.Bitmap(TempBitmap.Width,
        TempBitmap.Height);
    System.Drawing.Graphics NewGraphics = 
        System.Drawing.Graphics.FromImage(NewBitmap);
    NewGraphics.DrawImage(TempBitmap, new System.Drawing.Rectangle(0, 0, 
        TempBitmap.Width, TempBitmap.Height), 
        new System.Drawing.Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height),
        System.Drawing.GraphicsUnit.Pixel);
    NewGraphics.Dispose();
