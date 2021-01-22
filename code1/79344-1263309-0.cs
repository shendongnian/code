            Bitmap b1 = new Bitmap(fname1);
            Bitmap b2 = new Bitmap(fname2);
            if (b1.Height != b2.Height || b1.Width != b2.Width) {
               MessageBox.Show("Input files are not the same dimensions!");
               Application.Exit();
            }
            totalPixels = b1.Height * b1.Width * 4;
            Bitmap outImg = new Bitmap(b1.Width, b1.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            BitmapData b1Data = b1.LockBits(new Rectangle(0, 0, b1.Width, b1.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            BitmapData b2Data = b2.LockBits(new Rectangle(0, 0, b1.Width, b1.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            BitmapData oData = outImg.LockBits(new Rectangle(0, 0, b1.Width, b1.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            byte[] cur1 = new byte[b1Data.Stride * b1Data.Height];
            byte[] cur2 = new byte[b2Data.Stride * b2Data.Height];
            byte[] curOut = new byte[b2Data.Stride * b2Data.Height];
            Marshal.Copy(b1Data.Scan0, cur1, 0, b1Data.Stride * b1Data.Height);
            Marshal.Copy(b2Data.Scan0, cur2, 0, b2Data.Stride * b2Data.Height);
            for (int i = 0; i < b1Data.Stride * b1Data.Height; i += 4) {
               byte temp1 = cur1[i], temp2 = cur2[i], first = 0, second = 0;
               curOut[i] = 0;
               first = (byte) ((temp1 > temp2) ? temp1 - temp2 : temp2 - temp1);
               temp1 = cur1[i + 1];
               temp2 = cur2[i + 1];
               curOut[i + 1] = 0;
               second = (byte) ((temp1 > temp2) ? temp1 - temp2 : temp2 - temp1);
               temp1 = cur1[i + 2];
               temp2 = cur2[i + 2];
               curOut[i + 2] = (byte) ((temp1 > temp2) ? temp1 - temp2 : temp2 - temp1);
               curOut[i + 2] = (byte) ((first + second + curOut[i + 2]) * 255);
               curPixel = i;
            }
            Marshal.Copy(curOut, 0, oData.Scan0, b2Data.Stride * b2Data.Height);
            b1.UnlockBits(b1Data);
            b2.UnlockBits(b2Data);
            outImg.UnlockBits(oData);
            outImg.Save(outfile);
