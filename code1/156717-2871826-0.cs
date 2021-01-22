            BitmapData bmd = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bufferSize = bmd.Height * bmd.Stride;
            //create data buffer 
            byte[] bytes = new byte[bufferSize];
            // copy bitmap data into buffer
            Marshal.Copy(bmd.Scan0, bytes, 0, bytes.Length);
            // copy our buffer to the texture
            Texture2D t2d = new Texture2D(_graphics.GraphicsDevice, bmp.Width, bmp.Height, 1, TextureUsage.None, SurfaceFormat.Color);
            t2d.SetData<byte>(bytes);
            // unlock the bitmap data
            bmp.UnlockBits(bmd);
            return t2d;
