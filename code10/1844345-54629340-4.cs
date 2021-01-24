        private static Bitmap AddBorderToImage(Image image, int borderSize)
        {
            using (Bitmap bmp = new Bitmap(image.Width + 2 * borderSize,
                image.Height + 2 * borderSize))
            {
                using (Graphics destGraph = Graphics.FromImage(bmp))
                {
                    destGraph.FillRectangle(Brushes.Green, new Rectangle(new Point(0, 0), bmp.Size));
                    destGraph.DrawImage(image, new Point(borderSize, borderSize));
                }
                return bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), image.PixelFormat);
            }
        }
