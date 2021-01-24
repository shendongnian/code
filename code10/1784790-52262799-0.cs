     private Image BlendImageWithWindowBackgoundColorToSize(Image pImage, float pColorOpacity)
        {
            Image mResult = null;
            if (pImage != null)
            {
                ColorMatrix matrix = new ColorMatrix(new float[][]{
                new float[] {1F, 0, 0, 0, 0},
                new float[] {0, 1F, 0, 0, 0},
                new float[] {0, 0, 1F, 0, 0},
                new float[] {0, 0, 0, pColorOpacity, 0}, //opacity in rage [0 1]
                new float[] {0, 0, 0, 0, 1F}});
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(matrix);
                imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
                mResult = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                
                Image mImgSemiTransparent = (Image)mResult.Clone();
                Graphics g = Graphics.FromImage(mImgSemiTransparent);
                g.CompositingMode = CompositingMode.SourceOver; 
                g.CompositingQuality = CompositingQuality.HighQuality;           
                g.DrawImage(pImage, new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height), 0, 0, pImage.Width, pImage.Height, GraphicsUnit.Pixel, imageAttributes);
                Graphics gF = Graphics.FromImage(mResult);
                gF.Clear(Color.Red);
                gF.DrawImageUnscaled(mImgSemiTransparent, 0, 0, mImgSemiTransparent.Width, mImgSemiTransparent.Height);
            }
            return mResult;
        }
