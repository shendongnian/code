    /// <summary>
        /// Sharpens the specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="strength">strength erwartet werte zwische 0 - 99</param>
        /// <returns></returns>
        public Bitmap Sharpen(Image image, whichMatrix welcheMatrix , double strength)
        {
            double FaktorKorrekturWert = 0;
            //strenght muß für den jeweiligen filter angepasst werden
            switch (welcheMatrix)
            {
                case whichMatrix.Gaussian3x3:
                    //diese Matrix benötigt einen strenght Wert von 0 bis -9.9 default ist -2.5
                    //und einen korekturwert von 16
                    strength = (strength * -1) / 10;
                    FaktorKorrekturWert = 16;
                    break;
                case whichMatrix.Mean3x3:
                    //diese Matrix benötigt einen strenght Wert von 0 bis -9 default ist -2.25
                    //und einen Korrekturwert von 10
                    strength = strength * -9 / 100;
                    FaktorKorrekturWert = 10;
                    break;
                case whichMatrix.Gaussian5x5Type1:
                    //diese Matrix benötigt einen strenght Wert von 0 bis 2.5 default ist 1.25
                    //und einen Korrekturwert von 12
                    strength = strength * 2.5 / 100;
                    FaktorKorrekturWert = 12;
                    break;
                default:
                    break;
            }
            using (var bitmap = image as Bitmap)
            {
                if (bitmap != null)
                {
                    var sharpenImage = bitmap.Clone() as Bitmap;
                    int width = image.Width;
                    int height = image.Height;
                    // Create sharpening filter.
                    var filter = Matrix(welcheMatrix);
                    //const int filterSize = 3; // wenn die Matrix 3 Zeilen und 3 Spalten besitzt dann 3 bei 4 = 4 usw.                    
                    int filterSize = filter.GetLength(0);                   
                    double bias = 1.0 - strength;
                    double factor = strength / FaktorKorrekturWert;
                    //const int s = filterSize / 2;
                    int s = filterSize / 2; // Filtersize ist keine Constante mehr darum wurde der befehl const entfernt
                    var result = new Color[image.Width, image.Height];
                    // Lock image bits for read/write.
                    if (sharpenImage != null)
                    {
                        BitmapData pbits = sharpenImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                        // Declare an array to hold the bytes of the bitmap.
                        int bytes = pbits.Stride * height;
                        var rgbValues = new byte[bytes];
                        // Copy the RGB values into the array.
                        Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);
                        int rgb;
                        // Fill the color array with the new sharpened color values.
                        for (int x = s; x < width - s; x++)
                        {
                            for (int y = s; y < height - s; y++)
                            {
                                double red = 0.0, green = 0.0, blue = 0.0;
                                for (int filterX = 0; filterX < filterSize; filterX++)
                                {
                                    for (int filterY = 0; filterY < filterSize; filterY++)
                                    {
                                        int imageX = (x - s + filterX + width) % width;
                                        int imageY = (y - s + filterY + height) % height;
                                        rgb = imageY * pbits.Stride + 3 * imageX;
                                        red += rgbValues[rgb + 2] * filter[filterX, filterY];
                                        green += rgbValues[rgb + 1] * filter[filterX, filterY];
                                        blue += rgbValues[rgb + 0] * filter[filterX, filterY];
                                    }
                                    rgb = y * pbits.Stride + 3 * x;
                                    int r = Math.Min(Math.Max((int)(factor * red + (bias * rgbValues[rgb + 2])), 0), 255);
                                    int g = Math.Min(Math.Max((int)(factor * green + (bias * rgbValues[rgb + 1])), 0), 255);
                                    int b = Math.Min(Math.Max((int)(factor * blue + (bias * rgbValues[rgb + 0])), 0), 255);
                                    result[x, y] = System.Drawing.Color.FromArgb(r, g, b);
                                }
                            }
                        }
                        // Update the image with the sharpened pixels.
                        for (int x = s; x < width - s; x++)
                        {
                            for (int y = s; y < height - s; y++)
                            {
                                rgb = y * pbits.Stride + 3 * x;
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
        public enum whichMatrix
        {
            Gaussian3x3,
            Mean3x3,
            Gaussian5x5Type1
        }
        private double[,] Matrix(whichMatrix welcheMatrix)
        {
            double[,] selectedMatrix = null;
            switch (welcheMatrix)
            {
                case whichMatrix.Gaussian3x3:
                    selectedMatrix = new double[,]
                    { 
                        { 1, 2, 1, }, 
                        { 2, 4, 2, }, 
                        { 1, 2, 1, }, 
                    };
                    break;
                case whichMatrix.Gaussian5x5Type1:
                    selectedMatrix = new double[,]
                    { 
                        {-1, -1, -1, -1, -1},
                        {-1,  2,  2,  2, -1},
                        {-1,  2,  16, 2, -1},
                        {-1,  2, -1,  2, -1},
                        {-1, -1, -1, -1, -1} 
                    };
                    break;
                case whichMatrix.Mean3x3:
                    selectedMatrix =new double[,]
                    { 
                        { 1, 1, 1, }, 
                        { 1, 1, 1, }, 
                        { 1, 1, 1, }, 
                    };
                    break;
            }
            return selectedMatrix;
        }
