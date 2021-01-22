    static class IconTinter
    {
        internal static Bitmap TintedIcon(Image sourceImage, Color tintingColor)
        {
            // Following https://code.msdn.microsoft.com/ColorMatrix-Image-Filters-f6ed20ae
            Bitmap bmp32BppDest = new Bitmap(sourceImage.Width, sourceImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            float cr = tintingColor.R / 255.0f;
            float cg = tintingColor.G / 255.0f;
            float cb = tintingColor.B / 255.0f;
            // See [Rotate Hue using ImageAttributes in C#](http://stackoverflow.com/a/26573948/1429390)
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                           {new float[] { cr,  cg,  cb,  0,  0}, 
                            new float[] { cb,  cr,  cg,  0,  0}, 
                            new float[] { cg,  cb,  cr,  0,  0}, 
                            new float[] {  0,   0,   0,  1,  0}, 
                            new float[] {  0,   0,   0,  0,  1}
                           }
                           );
            using (Graphics graphics = Graphics.FromImage(bmp32BppDest))
            {
                ImageAttributes bmpAttributes = new ImageAttributes();
                bmpAttributes.SetColorMatrix(colorMatrix);
                graphics.DrawImage(sourceImage,
                    new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                    0, 0,
                    sourceImage.Width, sourceImage.Height,
                    GraphicsUnit.Pixel, bmpAttributes);
            }
            return bmp32BppDest;
        }
    }
