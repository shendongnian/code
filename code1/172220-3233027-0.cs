    public static Image DrawReflection(Image _Image, Color _BackgroundColor, int _Reflectivity)
    {
        // Calculate the size of the new image
        int height = (int)(_Image.Height + (_Image.Height * ((float)_Reflectivity / 255)));
        Bitmap newImage = new Bitmap(_Image.Width, height, PixelFormat.Format24bppRgb);
        newImage.SetResolution(_Image.HorizontalResolution, _Image.VerticalResolution);
    
        using (Graphics graphics = Graphics.FromImage(newImage))
        {
            // Initialize main graphics buffer
            graphics.Clear(_BackgroundColor);
            graphics.DrawImage(_Image, new Point(0, 0));
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle destinationRectangle = new Rectangle(0, _Image.Size.Height, 
                                             _Image.Size.Width, _Image.Size.Height);
    
            // Prepare the reflected image
            int reflectionHeight = (_Image.Height * _Reflectivity) / 255;
            Image reflectedImage = new Bitmap(_Image.Width, reflectionHeight);
    
            // Draw just the reflection on a second graphics buffer
            using (Graphics gReflection = Graphics.FromImage(reflectedImage))
            {
                gReflection.DrawImage(_Image, 
                   new Rectangle(0, 0, reflectedImage.Width, reflectedImage.Height),
                   0, _Image.Height - reflectedImage.Height, reflectedImage.Width, 
                   reflectedImage.Height, GraphicsUnit.Pixel);
            }
            reflectedImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Rectangle imageRectangle = 
                new Rectangle(destinationRectangle.X, destinationRectangle.Y,
                destinationRectangle.Width, 
                (destinationRectangle.Height * _Reflectivity) / 255);
    
            // Draw the image on the original graphics
            graphics.DrawImage(reflectedImage, imageRectangle);
    
            // Finish the reflection using a gradiend brush
            LinearGradientBrush brush = new LinearGradientBrush(imageRectangle,
                   Color.FromArgb(255 - _Reflectivity, _BackgroundColor),
                    _BackgroundColor, 90, false);
            graphics.FillRectangle(brush, imageRectangle);
        }
    
        return newImage;
    }
