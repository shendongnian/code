        public static Bitmap BitmapToGrayscale4bpp(Bitmap source)
        {
            // Create target image.
            int width = source.Width;
            int height = source.Height;
            Bitmap target = new Bitmap(width,height,PixelFormat.Format4bppIndexed);
            // Set the palette to discrete shades of gray
            ColorPalette palette = target.Palette;            
            for(int i = 0 ; i < palette.Entries.Length ; i++)
            {
                int cval = 17*i;
                palette.Entries[i] = Color.FromArgb(0,cval,cval,cval);
            }
            target.Palette = palette;
            // Lock bits so we have direct access to bitmap data
            BitmapData targetData = target.LockBits(new Rectangle(0, 0, width,height),
                                                    ImageLockMode.ReadWrite, PixelFormat.Format4bppIndexed);
            BitmapData sourceData = source.LockBits(new Rectangle(0, 0, width,height),
                                                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            
            unsafe
            {
                for(int r = 0 ; r < height ; r++)
                {
                    byte* pTarget = (byte*) (targetData.Scan0 + r*targetData.Stride);
                    byte* pSource = (byte*) (sourceData.Scan0 + r*sourceData.Stride);
                    byte prevValue = 0;
                    for(int c = 0 ; c < width ; c++)
                    {
                        byte colorIndex = (byte) ((((*pSource)*0.3 + *(pSource + 1)*0.59 + *(pSource + 2)*0.11)) / 16);
                        if (c % 2 == 0)
                            prevValue = colorIndex;
                        else
                            *(pTarget++) = (byte)(prevValue | colorIndex << 4);
                            
                        pSource += 3;
                    }
                }
            }
            target.UnlockBits(targetData);
            source.UnlockBits(sourceData);
            return target;
        }
