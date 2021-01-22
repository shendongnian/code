        public static void Negate(Bitmap image)
        {
                Bitmap clone = (Bitmap) image.Clone();
                using (Graphics g = Graphics.FromImage(image))
                {
                    // negation ColorMatrix
                    ColorMatrix colorMatrix = new ColorMatrix(
                        new float[][]
                            {
                                new float[] {-1, 0, 0, 0, 0},
                                new float[] {0, -1, 0, 0, 0},
                                new float[] {0, 0, -1, 0, 0},
                                new float[] {0, 0, 0, 1, 0},
                                new float[] {0, 0, 0, 0, 1}
                            });
                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(colorMatrix);
                    g.DrawImage(clone, new Rectangle(0, 0, clone.Width, clone.Height),
                                0, 0, clone.Width, clone.Height, GraphicsUnit.Pixel, attributes);
               }
        }
