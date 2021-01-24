    public unsafe Point? GetPoint(string main, string sub)
    {
       using (Bitmap m = new Bitmap(main), s = new Bitmap(sub))
       {
          Rectangle mR = new Rectangle(Point.Empty, m.Size), sR = new Rectangle(Point.Empty, s.Size);
          int mW = mR.Width, sW = sR.Width, mB = mR.Bottom, sB = sR.Bottom, mT = mR.Top, mL = mR.Left;
          var mD = m.LockBits(mR, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
          var sD = s.LockBits(sR, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
          int* m0 = (int*)mD.Scan0, s0 = (int*)sD.Scan0;
    
          for (int mX = mT, sX = 0; mX < mW; mX++, sX++)
          {
             for (int mY = mB, sY = 0; mY < mB; mY++, sY++)
             {
                var pm = m0 + mX + mY * mW;
                var ps = s0 + sX + sY * sW;
    
                if (sY >= sB)
                {
                   var result = true;
                   for (int sX1 = 1, mX1 = mX; sX < sW && mX1 < mW; sX++, mX1++)
                   {
                      for (int sY1 = 0, mY1 = mY; sY < sB && mY1 < mB; sY++, mY1++)
                      {
                         pm = m0 + mX1 + mY1 * mW;
                         ps = s0 + sX1 + sY1 * sW;
    
                         if (*pm == *ps)
                         {
                            continue;
                         }
    
                         result = false;
                         break;
                      }
    
                      if (result)
                      {
                         return new Point(mX, mY- sW);
                      }
                   }
    
                   sY = -1;
                }
    
    
                if (*pm != *ps)
                {
                   sY = -1;
                }           
             }
          }
       }    
       return null;
    }
