            Bitmap originalBMP = new Bitmap(pictureBox1.ImageLocation);
            Bitmap changedBMP = new Bitmap(pictureBox2.ImageLocation);
            int width = Math.Min(originalBMP.Width, changedBMP.Width),
                height = Math.Min(originalBMP.Height, changedBMP.Height),
                xMin = int.MaxValue,
                xMax = int.MinValue,
                yMin = int.MaxValue,
                yMax = int.MinValue;
            var originalLock = originalBMP.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, originalBMP.PixelFormat);
            var changedLock = changedBMP.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, changedBMP.PixelFormat);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //generate the address of the colour pixel
                    int pixelIdxOrg = y * originalLock.Stride + (x * 4);
                    int pixelIdxCh = y * changedLock.Stride + (x * 4);
                    if (( Marshal.ReadByte(originalLock.Scan0, pixelIdxOrg + 2)!= Marshal.ReadByte(changedLock.Scan0, pixelIdxCh + 2))
                        || (Marshal.ReadByte(originalLock.Scan0, pixelIdxOrg + 1) != Marshal.ReadByte(changedLock.Scan0, pixelIdxCh + 1))
                        || (Marshal.ReadByte(originalLock.Scan0, pixelIdxOrg) != Marshal.ReadByte(changedLock.Scan0, pixelIdxCh))
                        )
                    {
                        xMin = Math.Min(xMin, x);
                        xMax = Math.Max(xMax, x);
                        yMin = Math.Min(yMin, y);
                        yMax = Math.Max(yMax, y);
                    }
                }
            }
            originalBMP.UnlockBits(originalLock);
            changedBMP.UnlockBits(changedLock);
            var result = changedBMP.Clone(new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin), changedBMP.PixelFormat);
            pictureBox3.Image = result;
