     public static class Processor
        {
            public static byte[] ToArray(this Bitmap bmp) // bitmap to byte array using lockbits
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptr = data.Scan0;
                int numBytes = data.Stride * bmp.Height;
                byte[] bytes = new byte[numBytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, bytes, 0, numBytes);
                bmp.UnlockBits(data);
                return bytes;
            }
    
    
            public static int GetPixel(this byte[] array, int bpr, int x, int y) //find out if the given pixel is 0 or 1
            {
                int num = y * bpr + x / 8;
                return (array[num] >> 7- x%8) & 1;
            }
    
            public static List<Point> getDrawingPoints(this Point start, byte[] array, int width, int height) // get one 0 point (black point) and find all adjacent black points by traveling neighbors  
            {
                List<Point> points = new List<Point>();
                points.Add(start);
                int BytePerRow = (int)Math.Ceiling((double)width / 8);
                int counter = 0;
                do
                {
                    for (int i = Math.Max(0, points[counter].X - 1); i <= Math.Min(width - 1, points[counter].X + 1); i++)
                        for (int j = Math.Max(0, points[counter].Y - 1); j <= Math.Min(height - 1, points[counter].Y + 1); j++)
                            if (array.GetPixel(BytePerRow, i, j) == 0 && !points.Any(p => p.X == i && p.Y == j))
                                points.Add(new Point(i, j));
                    counter++;
                } while (counter < points.Count);
                return points;
            }
            public static Bitmap ToBitmap(this List<Point> points) // convert points to bitmap
            {
                
                int startX = points.OrderBy(p => p.X).First().X,
                    endX = points.OrderByDescending(p => p.X).First().X,
                    startY = points.OrderBy(p => p.Y).First().Y,
                    endY = points.OrderByDescending(p => p.Y).First().Y;
                Bitmap bmp = new Bitmap(endX - startX + 1, endY - startY + 1);
                Graphics g = Graphics.FromImage(bmp);
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, endX - startX - 1, endY - startY - 1));
                for (int i = startY; i <= endY; i++)
                    for (int j = startX; j <= endX; j++)
                        if (points.Any(p => p.X == j && p.Y == i)) bmp.SetPixel(j - startX, i - startY, Color.Black); 
                return bmp;
            }
        }
