    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool CheckSubImage(int* m0, int* s0, Rectangle mR, Rectangle sR, int x, int y, out Point? result)
    {
    
       result = null;
       for (int sX = 0, mX = x; sX < sR.Width && mX < mR.Right; sX++, mX++)
          for (int sY = 0, mY = y; sY < sR.Height && mY < mR.Bottom; sY++, mY++)
             if (*(m0 + mX + mY * mR.Width) != *(s0 + sX + sY * sR.Width))
                return false;
    
       result = new Point(x, y);
       return true;
    }
    
    protected override Point? GetPoint(string main, string sub)
    {
       using (Bitmap m = new Bitmap(main), s = new Bitmap(sub))
       {
          Rectangle mR = new Rectangle(Point.Empty, m.Size), sR = new Rectangle(Point.Empty, s.Size);
    
          var mD = m.LockBits(mR, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
          var sD = s.LockBits(sR, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
    
          int* m0 = (int*)mD.Scan0, s0 = (int*)sD.Scan0;
    
          for (var x = mR.Left; x < mR.Right; x++)
             for (var y = mR.Top; y < mR.Bottom; y++)
                if (*(m0 + x + y * mR.Width) == *s0)
                   if (CheckSubImage(m0, s0, mR, sR, x, y, out var result))
                      return result;
    
          m.UnlockBits(mD);
          s.UnlockBits(sD);
       }
    
       return null;
    }
