        private Texture2D Scale(GraphicsDevice gd, Texture2D texture, float scale)
        {
            int sourceWidth = texture.Width;
            int sourceHeight = texture.Height;
            int destWidth = (int)(sourceWidth * scale);
            int destHeight = (int)(sourceHeight * scale);
            //convert texture into bitmap
            byte[] textureData = new byte[4 * sourceWidth * sourceHeight];
            texture.GetData<byte>(textureData);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(sourceWidth, sourceHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, sourceWidth, sourceHeight), System.Drawing.Imaging.ImageLockMode.WriteOnly,
                           System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            IntPtr safePtr = bmpData.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(textureData, 0, safePtr, textureData.Length);
            bmp.UnlockBits(bmpData);
         
            //output bitmap
            System.Drawing.Image outputImage = new System.Drawing.Bitmap(destWidth, destHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(outputImage);
            grPhoto.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)(interpolationMode);
          
            grPhoto.DrawImage((System.Drawing.Image)bmp, new System.Drawing.Rectangle(0, 0, destWidth, destHeight),
                new System.Drawing.Rectangle(0, 0, sourceWidth, sourceHeight), System.Drawing.GraphicsUnit.Pixel);
            
            grPhoto.Dispose();
            textureData = new byte[4 * sourceWidth * sourceHeight];
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)outputImage).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            Texture2D result = Texture2D.FromFile(gd, ms);
            ms.Dispose();
            return result;
        }
