    // using Accord.Imaging;
    
    // using Accord.Imaging.Converters;
     
    
                int i;
                int arrayLen;
                double arraySum = 0;
                double arrayAverage = 0;
                double arrayLimit = 30;  // threshold for dark images
                bool isDark = true;
                Bitmap actBitmap = Accord.Imaging.Image.Clone(actFrame.GetVideoFrame());
                ImageToArray conv = new ImageToArray(min: 0, max: 255);
                conv.Convert(actBitmap, out double[] array);
                arrayLen = array.Length;
                for (i = 0; i < arrayLen; i++)
                {
                    arraySum = arraySum + array[i];
                }
                arrayAverage = (double)(arraySum / (double)arrayLen);
                if (arrayAverage < arrayLimit)
                {
                    isDark = true;
                }
                else
                {
                    isDark = false;
                }
                return isDark;
