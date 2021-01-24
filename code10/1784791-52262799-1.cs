            private Image BlendImageWithWindowBackgoundColorToSize2(Image pImage, float pColorOpacity)
        {
            Image mResult = null;
            Image tempImage = null; //we will set the opacity of pImage to pColorOpacity and copy
                                    //it to tempImage 
            if (pImage != null)
            {
                Graphics g;
                ColorMatrix matrix = new ColorMatrix(new float[][]{
                new float[] {1F, 0, 0, 0, 0},
                new float[] {0, 1F, 0, 0, 0},
                new float[] {0, 0, 1F, 0, 0},
                new float[] {0, 0, 0, pColorOpacity, 0}, //opacity in rage [0 1]
                new float[] {0, 0, 0, 0, 1F}});
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(matrix);
                imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
                tempImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                g = Graphics.FromImage(tempImage);
                //g.Clear(Color.Transparent); //No need!
                //setting pColorOpacity to pImage and drawing to tempImage 
                g.DrawImage(pImage, new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height), 0, 0, pImage.Width, pImage.Height, GraphicsUnit.Pixel, imageAttributes);
                g.Dispose();
                g = null;
                //now we will tile the tempImage
                TextureBrush texture = new TextureBrush(tempImage);
                
                mResult = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                      Screen.PrimaryScreen.Bounds.Height,
                                      PixelFormat.Format32bppArgb);
                g = Graphics.FromImage(mResult);
                g.Clear(myColor);
                g.FillRectangle(texture, new Rectangle(0, 0, mResult.Width, mResult.Height));
                g.Dispose();
                g = null;
                tempImage.Dispose();
                tempImage = null;
            }
            return mResult;
        }
