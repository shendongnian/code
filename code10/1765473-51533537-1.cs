    List<Bitmap> TintImages(Bitmap bmp0, List<Color> colors )
    {
        List<Bitmap> tinted = new List<Bitmap>();
        Size sz = bmp0.Size;
        float f = 256f;
        for (int i = 0; i < colors.Count; i++)
        {
            float r = colors[i].R / f;
            float g = colors[i].G / f;
            float b = colors[i].B / f;
            float[][] colorMatrixElements = {
                new float[] {r,  0,  0,  0, 0},        // red scaling factor of 1
                new float[] {0,  g,  0,  0, 0},        // green scaling factor of 1
                new float[] {0,  0,  b,  0, 0},        // blue scaling factor of 1
                new float[] {0,  0,  0,  1, 0},        // alpha scaling factor of 1
                new float[] {0, 0, 0, 0, 1}};         // three translations of 0
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            Bitmap bmp = new Bitmap(sz.Width, sz.Height);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(bmp0, new Rectangle(0, 0, sz.Width, sz.Height),
                0, 0, sz.Width, sz.Height, GraphicsUnit.Pixel, imageAttributes);
                tinted.Add(bmp);
            }
        }
        return tinted;
    }
