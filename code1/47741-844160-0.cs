            private static void CopyBitmapToDest(BitmapData sourcebtmpdata, BitmapData destbtmpdata, Point point)
        {
            byte[] src = new byte[sourcebtmpdata.Height * sourcebtmpdata.Width * 3];
            int maximum = src.Length;
            byte[] dest = new byte[maximum];
            Marshal.Copy(sourcebtmpdata.Scan0, src, 0, src.Length);
            int pointX = point.X * 3;
            int copyLength = destbtmpdata.Width*3 - pointX;
            int k = pointX + point.Y * sourcebtmpdata.Stride;
            int rowWidth = sourcebtmpdata.Stride;
            while (k<maximum)
            {
                Array.Copy(src,k,dest,k,copyLength);
                k += rowWidth;
            }
            Marshal.Copy(dest, 0, destbtmpdata.Scan0, dest.Length);
        }
 
