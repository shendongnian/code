    public static void resizeImage_n_save(Stream sourcePath, string targetPath, int requiredSize)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                double ratio = 0;
                var newWidth = 0;
                var newHeight = 0;
                double w = Convert.ToInt32(image.Width);
                double h = Convert.ToInt32(image.Height);
                if (w > h)
                {
                    ratio = h / w * 100;
                    newWidth = requiredSize;
                    newHeight = Convert.ToInt32(requiredSize * ratio / 100);
                }
                else
                {
                    ratio = w / h * 100;
                    newHeight = requiredSize;
                    newWidth = Convert.ToInt32(requiredSize * ratio / 100);
                }
                
                //   var newWidth = (int)(image.Width * scaleFactor);
                // var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
                //var img = FixedSize(image, requiredSize, requiredSize);
                //img.Save(targetPath, image.RawFormat);
            }
        }
