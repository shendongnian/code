    public static Image AutoCrop(this Bitmap bmp)
    {
        if (Image.GetPixelFormatSize(bmp.PixelFormat) != 32)
            throw new InvalidOperationException("Autocrop currently only supports 32 bits per pixel images.");
        // Initialize variables
        var cropColor = Color.White;
        var bottom = 0;
        var left = bmp.Width; // Set the left crop point to the width so that the logic below will set the left value to the first non crop color pixel it comes across.
        var right = 0;
        var top = bmp.Height; // Set the top crop point to the height so that the logic below will set the top value to the first non crop color pixel it comes across.
        var bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
        unsafe
        {
            var dataPtr = (byte*)bmpData.Scan0;
            for (var y = 0; y < bmp.Height; y++)
            {
                for (var x = 0; x < bmp.Width; x++)
                {
                    var rgbPtr = dataPtr + (x * 4);
                    var b = rgbPtr[0];
                    var g = rgbPtr[1];
                    var r = rgbPtr[2];
                    var a = rgbPtr[3];
                    // If any of the pixel RGBA values don't match and the crop color is not transparent, or if the crop color is transparent and the pixel A value is not transparent
                    if ((cropColor.A > 0 && (b != cropColor.B || g != cropColor.G || r != cropColor.R || a != cropColor.A)) || (cropColor.A == 0 && a != 0))
                    {
                        if (x < left)
                            left = x;
                        if (x >= right)
                            right = x + 1;
                        if (y < top)
                            top = y;
                        if (y >= bottom)
                            bottom = y + 1;
                    }
                }
                dataPtr += bmpData.Stride;
            }
        }
        bmp.UnlockBits(bmpData);
        if (left < right && top < bottom)
            return bmp.Clone(new Rectangle(left, top, right - left, bottom - top), bmp.PixelFormat);
        return null; // Entire image should be cropped, so just return null
    }
