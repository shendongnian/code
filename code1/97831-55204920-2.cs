    using Accord.Imaging;
    
    using Accord.Imaging.Converters;
        
        private bool IsDarkImage(Bitmap aBitmap, int darkThreshold)
        {
            double arrayAverage = 0;
            bool isDark = true;
            ImageToArray conv = new ImageToArray(min: 0, max: 255);
            conv.Convert(aBitmap, out double[] array);
            arrayAverage = (double) array.Sum() / (double) array.Length;
            if (arrayAverage < darkThreshold)
            {
                isDark = true;
            }
            else
            {
                isDark = false;
            }
            return isDark;
        }
