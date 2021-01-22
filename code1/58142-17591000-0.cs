    /// <summary>
    ///     Sharpens the specified image.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="strength">The strength between 0.0 and 1.0.</param>
    /// <returns></returns>
    public static Bitmap Sharpen(Image image, double strength)
    {
        using (var bitmap = image as Bitmap)
        {
            if (bitmap != null)
            {
                var sharpenImage = bitmap.Clone() as Bitmap;
    
                int width = image.Width;
                int height = image.Height;
    
                // Create sharpening filter.
                const int filterWidth = 5;
                const int filterHeight = 5;
    
                var filter = new double[,]
                    {
                        {-1, -1, -1, -1, -1},
                        {-1,  2,  2,  2, -1},
                        {-1,  2, 16,  2, -1},
                        {-1,  2,  2,  2, -1},
                        {-1, -1, -1, -1, -1}
                    };
    
                double bias = 1.0 - strength;
                double factor = strength/16.0;
    
                var result = new Color[image.Width,image.Height];
    
                // Lock image bits for read/write.
                if (sharpenImage != null)
                {
                    BitmapData pbits = sharpenImage.LockBits(new Rectangle(0, 0, width, height),
                                                                ImageLockMode.ReadWrite,
                                                                PixelFormat.Format24bppRgb);
    
                    // Declare an array to hold the bytes of the bitmap.
                    int bytes = pbits.Stride*height;
                    var rgbValues = new byte[bytes];
    
                    // Copy the RGB values into the array.
                    Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);
    
                    int rgb;
                    // Fill the color array with the new sharpened color values.
                    for (int x = 0; x < width; ++x)
                    {
                        for (int y = 0; y < height; ++y)
                        {
                            double red = 0.0, green = 0.0, blue = 0.0;
    
                            for (int filterX = 0; filterX < filterWidth; filterX++)
                            {
                                for (int filterY = 0; filterY < filterHeight; filterY++)
                                {
                                    int imageX = (x - filterWidth/2 + filterX + width)%width;
                                    int imageY = (y - filterHeight/2 + filterY + height)%height;
                                    rgb = imageY*pbits.Stride + 3*imageX;
                                    red += rgbValues[rgb + 2]*filter[filterX, filterY];
                                    green += rgbValues[rgb + 1]*filter[filterX, filterY];
                                    blue += rgbValues[rgb + 0]*filter[filterX, filterY];
                                }
                                rgb = y*pbits.Stride + 3*x;
                                int r = Math.Min(Math.Max((int) (factor*red + (bias*rgbValues[rgb + 2])), 0), 255);
                                int g = Math.Min(Math.Max((int) (factor*green + (bias*rgbValues[rgb + 1])), 0), 255);
                                int b = Math.Min(Math.Max((int) (factor*blue + (bias*rgbValues[rgb + 0])), 0), 255);
                                result[x, y] = Color.FromArgb(r, g, b);
                            }
                        }
                    }
                    // Update the image with the sharpened pixels.
                    for (int x = 0; x < width; ++x)
                    {
                        for (int y = 0; y < height; ++y)
                        {
                            rgb = y*pbits.Stride + 3*x;
                            rgbValues[rgb + 2] = result[x, y].R;
                            rgbValues[rgb + 1] = result[x, y].G;
                            rgbValues[rgb + 0] = result[x, y].B;
                        }
                    }
                    // Copy the RGB values back to the bitmap.
                    Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
                    // Release image bits.
                    sharpenImage.UnlockBits(pbits);
                }
                return sharpenImage;
            }
        }
        return null;
    }
