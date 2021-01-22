    class ImageHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            public BITMAPINFOHEADER(ushort bpp, int height, int width)
            {
                biBitCount = bpp;
                biWidth = width;
                biHeight = height;
                biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER));
                biPlanes = 1; // must be 1
                biCompression = 0; // no compression
                biSizeImage = 0; // no compression, so can be 0
                biXPelsPerMeter = 0;
                biYPelsPerMeter = 0;
                biClrUsed = 0;
                biClrImportant = 0;
            }
            public void Store(BinaryWriter bw)
            {
                Store(bw, null);
            }
            public void Store(BinaryWriter bw, uint[] colorPalette)
            {
                // Must maintain order for file writing
                bw.Write(biSize);
                bw.Write(biWidth);
                bw.Write(biHeight);
                bw.Write(biPlanes);
                bw.Write(biBitCount);
                bw.Write(biCompression);
                bw.Write(biSizeImage);
                bw.Write(biXPelsPerMeter);
                bw.Write(biYPelsPerMeter);
                bw.Write(biClrUsed);
                bw.Write(biClrImportant);
                // write color palette if 8 bpp or less
                if (biBitCount <= 8)
                {
                    if (colorPalette == null)
                        throw new ArgumentNullException("bpp is 8 or less, color palette is required");
                    uint paletteCount = BITMAPFILEHEADER.CalcPaletteSize(biBitCount) / 4;
                    if (colorPalette.Length < paletteCount)
                        throw new ArgumentException(string.Format("bpp is 8 or less, color palette must contain {0} colors", paletteCount));
                    foreach (uint color in colorPalette)
                        bw.Write(color);
                }
            }
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPFILEHEADER
        {
            public BITMAPFILEHEADER(BITMAPINFOHEADER info, out uint sizeOfImageData)
            {
                bfType = 0x4D42;  // Microsoft supplied value to indicate Bitmap 'BM'
                bfReserved1 = 0;
                bfReserved2 = 0;
                // calculate amount of space needed for color palette
                uint paletteSize = CalcPaletteSize(info.biBitCount);
                bfOffBits = 54 + paletteSize; // default value + paletteSize
                // calculate size of image
                sizeOfImageData = (uint)(CalcRowSize(info.biWidth * info.biBitCount) * info.biHeight);
                bfSize = sizeOfImageData + bfOffBits;
            }
            private static int CalcRowSize(int bits)
            {
                return ((((bits) + 31) / 32) * 4);
            }
            public static uint CalcPaletteSize(int bpp)
            {
                // 8 bpp or less, needs an uint per color
                if (bpp <= 8)
                    return 4 * (uint)Math.Pow(2, bpp);
                // no palette needed for 16bpp or higher
                return 0;
            }
            public void Store(BinaryWriter bw)
            {
                // Must maintain order for file writing
                bw.Write(bfType);
                bw.Write(bfSize);
                bw.Write(bfReserved1);
                bw.Write(bfReserved2);
                bw.Write(bfOffBits);
            }
            public ushort bfType;
            public uint bfSize;
            public short bfReserved1;
            public short bfReserved2;
            public uint bfOffBits;
        }
        public static byte[] GetByteArray(Bitmap image)
        {
            IntPtr hbmOld;
            IntPtr hBitmap;
            IntPtr hDC;
            // create infoheader
            BITMAPINFOHEADER bih = new BITMAPINFOHEADER(1, image.Height, image.Width);
            // set black and white for 1 bit color palette
            // create fileheader and get data size
            uint sizeOfImageData;
            BITMAPFILEHEADER bfh = new BITMAPFILEHEADER(bih, out sizeOfImageData);
            // create device context in memory
            hDC = Win32.CreateCompatibleDC(IntPtr.Zero);
            // create a 1 bpp DIB
            IntPtr pBits = IntPtr.Zero;
            hBitmap = Win32.CreateDIBSection(hDC, ref bih, 1, ref pBits, IntPtr.Zero, 0);
            // selet DIB into device context
            hbmOld = Win32.SelectObject(hDC, hBitmap);
            using (Graphics g = Graphics.FromHdc(hDC))
            {
                 g.DrawImage(image, 0, 0);
            }
            byte[] imageData = new byte[sizeOfImageData];
            byte[] fileData;
            using (MemoryStream ms = new MemoryStream((int)bfh.bfSize))
            {
                using (BinaryWriter w = new BinaryWriter(ms))
                {
                    bfh.Store(w);
                    // store bitmapinfoheader with 1 bpp color palette for black and white
                    bih.Store(w, new uint[] { (uint)0x0, (uint)0xffffff });
                    // copy image data into imageData buffer
                    Marshal.Copy(pBits, imageData, 0, imageData.Length);
                    // write imageData to stream
                    w.Write(imageData);
                    w.Close();
                }
                fileData = ms.GetBuffer();
                ms.Close();
            }
            // select old object
            if (hbmOld != IntPtr.Zero)
                Win32.SelectObject(hDC, hbmOld);
            // delete memory bitmap
            if (hBitmap != IntPtr.Zero)
                Win32.DeleteObject(hBitmap);
            // delete memory device context
            if (hDC != IntPtr.Zero)
                Win32.DeleteDC(hDC);
            return fileData;
        }
    }
