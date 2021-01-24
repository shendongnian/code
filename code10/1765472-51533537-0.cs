    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        string filepath = @"D:\mount.png";
        List<Color> colors = new List<Color>()
        { Color.Red, Color.Orange, Color.Gold, Color.LightYellow,
            Color.MediumSeaGreen, Color.Teal, Color.Blue,
            Color.MediumVioletRed, Color.Fuchsia};
        Bitmap bmp0 = (Bitmap)Bitmap.FromFile(filepath);
        Size sz = bmp0.Size;
        // center my output, optional    
        e.Graphics.TranslateTransform(50,50);
        float f = 256f;
        for (int i = 0; i < colors.Count; i++)
        {
            string newpath = filepath.Replace(".png", i + ".png");
            float r = colors[i].R / f;
            float g = colors[i].G / f;
            float b = colors[i].B / f;
            float[][] colorMatrixElements = { 
                new float[] {r, 0, 0, 0, 0},        // red scaling factor
                new float[] {0, g, 0, 0, 0},        // green scaling factor 
                new float[] {0, 0, b, 0, 0},        // blue scaling factor 
                new float[] {0, 0, 0, 1, 0},        // alpha scaling factor 
                new float[] {0, 0, 0, 0, 1}};       // no further translations
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            // optionally draw
            Rectangle destRect = new Rectangle(sz.Width * (i % 3), sz.Height * (i / 3),
                                               sz.Width, sz.Height);
            e.Graphics.DrawImage(bmp0, destRect, 0, 0, sz.Width, sz.Height,    
                                 GraphicsUnit.Pixel, imageAttributes);
            // create tinted bitmaps and save to disk
            using (Bitmap tinted = new Bitmap(sz.Width, sz.Height))
            using (Graphics gr = Graphics.FromImage(tinted))
            {
                gr.DrawImage(bmp0,    new Rectangle(0, 0, sz.Width, sz.Height), 
                0, 0, sz.Width, sz.Height, GraphicsUnit.Pixel,   imageAttributes);
                tinted.Save(newpath, ImageFormat.Png);
            }
            bmp0.Dispose();
        }
    }
