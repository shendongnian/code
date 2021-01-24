            private string GetBase64Data(byte [] image)
        {
            var data = string.Empty;
            using (MemoryStream ms = new MemoryStream(image))
            {
                using (Tiff tif = Tiff.ClientOpen("in-memory", "r", ms, new TiffStream()))
                {
                    // Find the width and height of the image
                    FieldValue[] value = tif.GetField(TiffTag.IMAGEWIDTH);
                    int width = value[0].ToInt();
                    value = tif.GetField(TiffTag.IMAGELENGTH);
                    int height = value[0].ToInt();
                    // Read the image into the memory buffer
                    int[] raster = new int[height * width];
                    if (!tif.ReadRGBAImage(width, height, raster))
                    {
                        return data;
                    }
                    using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                    {
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        BitmapData bmpdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                        byte[] bits = new byte[bmpdata.Stride * bmpdata.Height];
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            int rasterOffset = y * bmp.Width;
                            int bitsOffset = (bmp.Height - y - 1) * bmpdata.Stride;
                            for (int x = 0; x < bmp.Width; x++)
                            {
                                int rgba = raster[rasterOffset++];
                                bits[bitsOffset++] = (byte)((rgba >> 16) & 0xff);
                                bits[bitsOffset++] = (byte)((rgba >> 8) & 0xff);
                                bits[bitsOffset++] = (byte)(rgba & 0xff);
                            }
                        }
                        System.Runtime.InteropServices.Marshal.Copy(bits, 0, bmpdata.Scan0, bits.Length);
                        bmp.UnlockBits(bmpdata);
                        MemoryStream ims = new MemoryStream();
                        bmp.Save(ims, ImageFormat.Bmp);
                        data = Convert.ToBase64String(ims.ToArray());
                    }
                }
            }
            return data;
        }
