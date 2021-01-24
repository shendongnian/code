    private static unsafe void Main(string[] args)
    {
       
       // some random objects
       _objects = Enumerable.Range(0, _rand.Next(5,10))
                            .Select((i, i1) => new FillObject(_rand.Next(1, 50), _rand.NextColor()))
                            .ToList();
    
       // make sure we have a 1 with a width of 1 to fill stuff in
       _objects.Add(new FillObject(1, _rand.NextColor()));
    
       // useful for later
       _largest = _objects.Max(x => x.Width);
    
       // size of the workspace
       var size = _rand.Next(1000, 1000);
    
       // i used an image you could just fix an array and pass it in
       using (var bmp = new Bitmap(size, size, PixelFormat.Format32bppArgb))
       {
       
          var bitmapData = bmp.LockBits(new Rectangle(0, 0, size, size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
          var data = (int*)bitmapData.Scan0;
          Generate(new Size(size, size), data);
          bmp.UnlockBits(bitmapData);
          bmp.Save(@"D:\TestImage.bmp");   
       }    
    }
