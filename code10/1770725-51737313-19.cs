    private static unsafe void Main(string[] args)
    {
    
       _objects = Enumerable.Range(0, 25)
                            .Select((i, i1) => new FillObject(i, _rand.NextColor()))
                            .ToList();
    
       _largest = _objects.Max(x => x.Width);
    
       var size = _rand.Next(100, 100);
    
       using (var bmp = new Bitmap(size, size, PixelFormat.Format32bppPArgb))
       {
          var bitmapData = bmp.LockBits(new Rectangle(0, 0, size, size), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
          var data = (int*)bitmapData.Scan0;
          Generate(new Size(size, size), data, 1);
          bmp.UnlockBits(bitmapData);
          bmp.Save(@"D:\TestImage.bmp");
       }
    }
