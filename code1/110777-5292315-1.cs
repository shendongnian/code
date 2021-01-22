        public class RGBColor
        {
            public byte R { get; set; }
            public byte G { get; set; }
            public byte B { get; set; }
            public uint Value
            {
                get
                {
                    return (uint)(((uint)R << 16) + ((uint)G << 8) + (B) + ((uint)255 << 24));
                }
            }
        }
       public static RGBColor GetPixel(this WriteableBitmap bmp, uint x, uint y)
        {
            unsafe
            {
                if (y >= bmp.PixelHeight) return default(RGBColor);
                if (x >= bmp.PixelWidth) return default(RGBColor);
                // Get a pointer to the back buffer.
                uint pBackBuffer = (uint)bmp.BackBuffer;
                // Find the address of the pixel to draw.
                pBackBuffer += y * (uint)bmp.BackBufferStride;
                pBackBuffer += x * 4;
                byte* pCol = (byte*)pBackBuffer;
                return new RGBColor() { B = pCol[0], G = pCol[1], R = pCol[2] };
            }
        }
        public static void SetPixel(this WriteableBitmapProxy bmp, uint x, uint y, RGBColor col)
        {
            SetPixel(bmp, x, y, col.Value);
        }
        public static void SetPixel(this WriteableBitmapProxy bmp, uint x, uint y, uint value)
        {
            unsafe
            {
                if (y >= bmp.PixelHeight) return;
                if (x >= bmp.PixelWidth) return;
                // Get a pointer to the back buffer.
                uint pBackBuffer = (uint)bmp.BackBuffer;
                // Find the address of the pixel to draw.
                pBackBuffer += y * (uint)bmp.BackBufferStride;
                pBackBuffer += x * 4;
                // Assign the color data to the pixel.
                *((uint*)pBackBuffer) = value;
            }
        }
