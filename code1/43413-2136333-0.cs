                            Bitmap bmp = new Bitmap("c:\\picture.jpg");
                            // Lock the bitmap's bits.  
                            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                            System.Drawing.Imaging.BitmapData bmpData =
                                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                bmp.PixelFormat);
                            // Get the address of the first line.
                            IntPtr ptr = bmpData.Scan0;
                            // Declare an array to hold the bytes of the bitmap.
                            int bytes = bmpData.Stride * bmp.Height;
                            byte[] rgbValues = new byte[bytes];
                            // Copy the RGB values into the array.
                            //This causes read or write protected memory
                            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
