    (byte r, byte g, byte b) GetPixel(byte[] image,int x, int y, int bytesPerPixel,int stride)
            {
                if (bytesPerPixel < 3) throw new ArgumentException(nameof(bytesPerPixel));
                byte b = image[x * bytesPerPixel + y * stride + 0];
                byte g = image[x * bytesPerPixel + y * stride + 1];
                byte r = image[x * bytesPerPixel + y * stride + 2];
                return (r, g, b);
            }
    
            byte ToGray((byte r, byte g, byte b) pixel)
            {
                return NearestByte((int)(pixel.r * 0.3 + pixel.g * 0.59 + pixel.b * 0.11));
            }
    
            byte NearestByte(int a)
            {
                return (byte)(Math.Min(255, Math.Max(0, a)));
            }
    
            void SetPixel(byte[] image, byte intensity, int x, int y, int bytesPerPixel, int stride)
            {
                if (bytesPerPixel < 3) throw new ArgumentException(nameof(bytesPerPixel));
                image[x * bytesPerPixel + y * stride + 0] = intensity;
                image[x * bytesPerPixel + y * stride + 1] = intensity;
                image[x * bytesPerPixel + y * stride + 2] = intensity;
            }
    
            Bitmap ApplyLaplacianFilter(Bitmap input)
            {            
                Bitmap img = new Bitmap(input);         
    
                // Lock the bitmap's bits.  
                Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    img.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    img.PixelFormat);
    
                IntPtr ptr = bmpData.Scan0;
                var stride = bmpData.Stride;
                int bytesPerPixel = bmpData.Stride / img.Width;
                int bytes = img.Width * img.Height * bytesPerPixel;
                byte[] rgbValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                img.UnlockBits(bmpData);
                int resultBytesPerPixel = 3;
                Bitmap resultBitmap = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);            
                var bitmapData = resultBitmap.LockBits(rect, ImageLockMode.ReadWrite, resultBitmap.PixelFormat);
    
                int resultStride = bitmapData.Stride;
                
                int resultBytes = resultStride * img.Height;
    
                byte[] result = new byte[resultBytes];
                
                for (int y = 1; y < img.Height - 1; y++)
                {
                    for (int x = 1; x < img.Width - 1; x++)
                    {
    
                        var left = GetPixel(rgbValues, x - 1, y, bytesPerPixel, stride);
                        var right = GetPixel(rgbValues, x + 1, y, bytesPerPixel, stride);
                        var top = GetPixel(rgbValues, x, y - 1, bytesPerPixel, stride);
                        var bottom = GetPixel(rgbValues, x, y + 1, bytesPerPixel, stride);
                        var center = GetPixel(rgbValues, x, y, bytesPerPixel, stride);
    
                        var resultIntensity = NearestByte(
                            ToGray(left) + ToGray(top) + ToGray(center) * (-4) + ToGray(right) + ToGray(bottom));
                        SetPixel(result, resultIntensity, x, y, resultBytesPerPixel, resultStride);
                    }
                }
                
                
                IntPtr resultPtr = bitmapData.Scan0;
                System.Runtime.InteropServices.Marshal.Copy(result, 0, resultPtr, resultBytes);
                resultBitmap.UnlockBits(bitmapData);            
                return resultBitmap;
    
            }
            private async void button1_Click(object sender, EventArgs e)
            {
                pictureBox2.Image = await new TaskFactory().StartNew((image) => ApplyLaplacianFilter((Bitmap)image), pictureBox1.Image);                       
            }
