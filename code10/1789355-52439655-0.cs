    unsafe public static void Main()
    {
       var height = 2;
       var width = 2;
       var output = new byte[4] { 1, 2, 3, 4};
       using (var bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed))
       {
          var data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
          Marshal.Copy(data.Scan0, output, 0, 4);
          bitmap.UnlockBits(data);
          bitmap.Save(@"D:\blah.bmp");
       }
    }
