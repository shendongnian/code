        private static Bitmap AddBorderToImage(Image image, int borderSize)
        {
            // Create the new bitmap
            Bitmap bmp = new Bitmap(image.Width + 2 * borderSize,
                image.Height + 2 * borderSize);
            using (Graphics destGraph = Graphics.FromImage(bmp))
            {
                // Fill the new bitmap the border color 
                destGraph.FillRectangle(Brushes.Green, new Rectangle(new Point(0,0), bmp.Size));
                // Draw the inner image
                destGraph.DrawImage(image, new Point(borderSize, borderSize));
            }
            return bmp;
        }
