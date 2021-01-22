       BitmapData bmd=bm.LockBits(new Rectangle(0, 0, 10, 10), System.Drawing.Imaging.ImageLockMode.ReadOnly, bm.PixelFormat);
          int PixelSize=4;
          for(int y=0; y<bmd.Height; y++)
          {
            byte* row=(byte *)bmd.Scan0+(y*bmd.Stride);
            for(int x=0; x<bmd.Width; x++)
            {
              row[x*PixelSize]=255;
            }
          } // it is copied from the last provided link.
