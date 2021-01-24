    protected unsafe void DoStuff(string path)
    {
    
       ...
    
       using (var b = new Bitmap(path))
       {
          var r = new Rectangle(Point.Empty, b.Size);
          var data = b.LockBits(r, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb); 
          var p = (int*)data.Scan0;
    
          try
          {
             for (int i = 0; i < 16; i++, Y++)
                for (int j = 0, X = 0; j < 9; j++, X++)
                   *(p + X + Y * r.Width) = character[i][j] == 1 ? BG : FG;
          }
          finally
          {
             b.UnlockBits(data);
          }
       }
    }
