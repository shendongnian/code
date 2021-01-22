    #define useUnsafe
    
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System;
    using System.Windows.Forms;
    
    namespace Utils
    {
        /// <summary>
        /// Provides extension methods for the Cursor class
        /// </summary>
        /// <remarks>By Aaron Murgatroyd</remarks>
        public static class CursorExtensionMethods
        {
            #region API Functions
    
            /// <summary>
            /// Contains the icon information for a Windows API icon
            /// </summary>
            private struct IconInfo
            {
                public bool fIcon;
                public int xHotspot;
                public int yHotspot;
                public IntPtr hbmMask;
                public IntPtr hbmColor;
            }
    
            /// <summary>
            /// Gets the icon information for a Windows API icon
            /// </summary>
            /// <param name="hIcon">The icon to get the info for</param>
            /// <param name="pIconInfo">The object to receive the info</param>
            /// <returns>True on success, false on failure</returns>
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
            [DllImport("gdi32.dll")]
            static extern bool DeleteObject(IntPtr hObject);
            #endregion
    
            #region Private Static Methods
    
            /// <summary>
            /// Scans bits in bitmap data for a set or unset bit
            /// </summary>
            /// <param name="byteData">The pointer to the first byte of the first scanline</param>
            /// <param name="start">The vertical position to start the scan</param>
            /// <param name="lineInc">The number of bytes to move per line</param>
            /// <param name="maxLines">The number of lines to scan</param>
            /// <param name="set">True to scan for set bits, false to scan for unset bits</param>
            /// <param name="fromBottom">True to scan from the bottom of the bitmap, false to scan from the top</param>
            /// <returns>The number of lines scanned before a bit was found, or -1 if none found before reaching max lines</returns>
    #if useUnsafe
            private static unsafe int ScanBits(IntPtr byteData, int start, int lineInc, int maxLines, bool set, bool fromBottom)
    #else
            private static int ScanBits(IntPtr byteData, int start, int lineInc, int maxLines, bool set, bool fromBottom)
    #endif
            {
                // Calculate the starting byte of the first scanline
    #if useUnsafe
                byte* lbLine = ((byte*)byteData) + (start * lineInc);
    #else
                int lbLine = ((int)(byteData) + (start * lineInc));
    #endif
    
                int liLine = 0;
    
                // Use lineInc to determines bytes per line
                int liBytesPerLine = (lineInc < 0 ? -lineInc : lineInc);
    
                // If we want to search in reverse order
                if (fromBottom)
                {
                    // Move to the START of the line
                    lbLine += lineInc * (maxLines - 1);
    
                    // Negate the line increment
                    lineInc = -lineInc;
                }
    
                while (maxLines > 0)
                {
                    // Setup the line scan
    #if useUnsafe
                    byte* lbData = lbLine;
    #else
                    int lbData = lbLine;
    #endif
                    int liByte = liBytesPerLine;
    
                    // For each byte in the line
                    while (liByte > 0)
                    {
    #if !useUnsafe
                        byte lbByte = Marshal.ReadByte((IntPtr)lbData);
    #endif
    
                        // If we want set bits, and a bit is set
    #if useUnsafe
                        if (set && *lbData != 0)
    #else
                        if (set && lbByte != 0)
    #endif
                            // Return the line number
                            return liLine;
                        else
                            // If we want unset bits and any bits arent set
    #if useUnsafe
                            if (!set && *lbData != byte.MaxValue)
    #else
                            if (!set && lbByte != byte.MaxValue)
    #endif
                                // Return the line number
                                return liLine;
    
                        // Next byte for scan line
                        liByte--;
                        lbData++;
                    }
    
                    // Next scan line
                    liLine++;
                    maxLines--;
                    lbLine += lineInc;
                }
    
                // If all lines were scanned, return -1
                if (maxLines == 0)
                    return -1;
                else
                    // Return number of lines scanned
                    return liLine;
            }
    
            #endregion
    
            #region Public Static Methods
    
            /// <summary>
            /// Gets the number of pixels between the Y hotspot 
            /// and the last physical line of a cursor
            /// </summary>
            /// <param name="cursor">The cursor to scan</param>
            /// <returns>
            /// The number of lines between the Y hotspot
            /// and the last physical line of the cursor
            /// </returns>
            public static int GetBaseLineHeight(this Cursor cursor)
            {
                return GetBaseLine(cursor) - cursor.HotSpot.Y;
            }
    
            /// <summary>
            /// Gets the physical base line of the cursor, that is,
            /// the distance between the top of the virtual cursor
            /// and the physical base line of the cursor
            /// </summary>
            /// <param name="cursor">The cursor to scan</param>
            /// <returns>The number of lines between the top of the virtual cursor 
            /// and the physical base line of the curosr</returns>
            public static int GetBaseLine(this Cursor cursor)
            {
                IconInfo liiInfo = new IconInfo();
    
                if (!GetIconInfo(cursor.Handle, ref liiInfo))
                    return cursor.Size.Height;
    
                Bitmap lbmpBitmap = Bitmap.FromHbitmap(liiInfo.hbmMask);
    
                try
                {
                    BitmapData lbdData = lbmpBitmap.LockBits(
                        new Rectangle(0, 0, lbmpBitmap.Width, lbmpBitmap.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
    
                    try
                    {
                        // Calculate number of lines in AND scan before any found
                        int liLine = ScanBits(lbdData.Scan0, 0, lbdData.Stride, cursor.Size.Height, false, true);
    
                        // If no AND scan bits found then scan for XOR bits
                        if (liLine == -1 && lbdData.Height == cursor.Size.Height * 2)
                            liLine = ScanBits(lbdData.Scan0, cursor.Size.Height, lbdData.Stride, cursor.Size.Height, true, true);
    
                        return cursor.Size.Height-liLine;
                    }
                    finally
                    {
                        lbmpBitmap.UnlockBits(lbdData);
                    }
                }
                finally
                {
                    DeleteObject(liiInfo.hbmMask);
                    DeleteObject(liiInfo.hbmColor);
                    lbmpBitmap.Dispose();
                }
            }
    
            #endregion
        }
    }
