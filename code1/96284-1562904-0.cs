    Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Red);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image,
                    new Rectangle(destinationX, destinationY, destinationWidth, destinationHeight),
                    new Rectangle(sourceX, sourceY, originalWidth, originalHeight),
                    GraphicsUnit.Pixel);
            }
            return bitmap;
