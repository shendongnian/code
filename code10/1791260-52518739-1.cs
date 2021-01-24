     List<Point> processed = new List<Point>();
     Bitmap bmp = ((Bitmap)Bitmap.FromFile(SourceBitmapPath));
     byte[] array = bmp.ToArray();
     int BytePerRow = (int)Math.Ceiling((double)bmp.Width / 8);
     int imgIndex = 1;
     for (int i = 0; i < bmp.Width; i++)
         for (int j = 0; j < bmp.Height; j++)
         {
              if (array.GetPixel(BytePerRow, i, j) == 0 && !processed.Any(p => p.X == i && p.Y == j))
              {
                   List<Point> points = new Point(i, j).getDrawingPoints(array, bmp.Width, bmp.Height);
                   processed.AddRange(points);
                   Bitmap result = points.ToBitmap();
                   result.Save($"{imgIndex++}.bmp");
               }
                        
          }
