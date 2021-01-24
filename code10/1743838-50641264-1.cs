        public Bitmap MergeTwoImages(Image firstImage, Bitmap secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }
            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }
            int outputImageWidth = firstImage.Width > secondImage.Width ? firstImage.Width : secondImage.Width;
            int outputImageHeight = firstImage.Height + secondImage.Height + 1;
            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(firstImage, new Point(0, 0));
                graphics.DrawImage(secondImage, new Point(0, firstImage.Height + 1));
            }
            return outputImage;
        }
