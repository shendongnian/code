      public Bitmap CreateThumbnail(Bitmap RawImage)
        {
            int width = RawImage.Width;
            int height = RawImage.Height;
            Size ThumbnailDimensions = new Size();
            ThumbnailDimensions.Width = 100;
            ThumbnailDimensions.Height = 100;
            
            Rectangle cropArea = new Rectangle();
            if (width > height)
            {               
                cropArea.Width = height;
                cropArea.Height = height;
                cropArea.X = 0;
                cropArea.Y = 0;                
            }
            else if (width < height)
            {
                cropArea.Width = width;
                cropArea.Height = width;
                cropArea.X = 0;
                cropArea.Y = 0;
            }
            if(width != height) Bitmap thumbnail = CropImage(RawImage, cropArea);
            
            thumbnail = ResizeImage(thumbnail, ThumbnailDimensions);
            return thumbnail;
        }
