    private unsafe static void Main(string[] args)
    {
       var height = 600;
       var width = 600;
       var p1 = new Point(0, 0);
       var p2 = new Point(width, 0);
       var p3 = new Point(width / 2, height);
       var r = new Random();
       var p = new Point(r.Next(0, width), r.Next(0, width));
    
       using (var im = new Bitmap(width, height, PixelFormat.Format32bppPArgb))
       {
     
          var data = im.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
          var sc0 = (int*)data.Scan0;
          var pLen = sc0 + height * width;
    
          var black = Color.Black.ToArgb();
          var white = Color.White.ToArgb();
    
          for (var pI = sc0; pI < pLen; pI++)
             *pI = black;
        
          for (long i = 0; i < width * height; i++)
          {
             Point tp;
             switch (r.Next(0, 3))
             {
                case 0:
                   tp = new Point((p1.X + p.X) / 2, (p1.Y + p.Y) / 2);
                   *(sc0 + tp.Y + tp.X * width) = white;
                   p = tp;
                   break;
                case 1:
                   tp = new Point((p2.X + p.X) / 2, (p2.Y + p.Y) / 2);
                   *(sc0 + tp.Y + tp.X * width) = white;
                   p = tp;
                   break;
                case 2:
                   tp = new Point((p3.X + p.X) / 2, (p3.Y + p.Y) / 2);
                   *(sc0 + tp.Y + tp.X * width) = white;
                   p = tp;
                   break;
             }
          }
          im.UnlockBits(data);
          im.Save(@"D:\img.png", ImageFormat.Png);
       }
    }
