      public void xPix(Bitmap bmp, int n, Color cx, Color nx)
      {
         var img = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
         byte[] bmpBytes = new byte[Math.Abs(img.Stride) * img.Height];
         System.Runtime.InteropServices.Marshal.Copy(img.Scan0, bmpBytes, 0, bmpBytes.Length);
         for (int y = 0; y < img.Height; y++)
         {
            for (int x = 0; x < img.Width; x += (n * 2))
            {
               cx = Color.FromArgb(BitConverter.ToInt32(bmpBytes, y * img.Stride + x * 4));
               if (x + n <= img.Width - 1) nx = Color.FromArgb(BitConverter.ToInt32(bmpBytes, y * img.Stride + x * 4));
               BitConverter.GetBytes(nx.ToArgb()).CopyTo(bmpBytes, y * img.Stride + x * 4);
               if (x + n <= img.Width - 1) BitConverter.GetBytes(cx.ToArgb()).CopyTo(bmpBytes, y * img.Stride + (x + n) * 4);
            }
         }
         System.Runtime.InteropServices.Marshal.Copy(bmpBytes, 0, img.Scan0, bmpBytes.Length);
         bmp.UnlockBits(img);
      }
      protected override void OnClick(EventArgs e)
      {
         base.OnClick(e);
         Bitmap bmp = new Bitmap(@"C:\Users\bluem\Downloads\Default.png");
         for (int i = 0; i < bmp.Width; i++)
         {
            xPix(bmp, new Random().Next(20) + 1, System.Drawing.Color.White, System.Drawing.Color.Green);
         }
         Canvas.Image = bmp;
      }
