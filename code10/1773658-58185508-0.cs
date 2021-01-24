    public static bool Offset(Bitmap b_mapa, int threshold)
            {
                int threshold3 = threshold * 3;
                int red, green, blue;
                BitmapData bmData = b_mapa.LockBits(new Rectangle(0, 0, b_mapa.Width, b_mapa.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;
                unsafe
                {
                    byte* p = (byte*)(void*)Scan0;
                    int nOffset = stride - b_mapa.Width * 3;
                    for (int y = 0; y < b_mapa.Height; ++y)
                    {
                        for (int x = 0; x < b_mapa.Width; ++x)
                        {
                            blue = p[0];
                            green = p[1];
                            red = p[2];
                            int v = ((int)(blue + green + red) > threshold3 ? (int)255 : (int)0);
                            p[0] = p[1] = p[2] = (byte)v;
                            p += 3;
                        }
                        p += nOffset;
                    }
                }
                b_mapa.UnlockBits(bmData);
                return true;
            }
