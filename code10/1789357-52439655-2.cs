    public static void Main()
    {
       var height = 2;
       var width = 2;
       var c = Color.White.ToArgb();
       var output = new int[4] { c, c, c, c };
       using (var bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed))
       {
          var data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
    
          Marshal.Copy(output, 0, data.Scan0, 4);
          bitmap.UnlockBits(data);
          bitmap.Save(@"D:\trdy.bmp");
       }
    }
