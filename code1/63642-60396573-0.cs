     public static void SaveJpg(string fileName,int sizeX,int sizeY,ushort [] imData)
        {
            var bitmap = new Bitmap(sizeX, sizeY, PixelFormat.Format48bppRgb);
            int count = 0;
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(imData[count], imData[count], imData[count]));
                    count++;
                }
            }
            bitmap.Save(fileName, ImageFormat.Jpeg);
        
        }
