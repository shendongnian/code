    static unsafe void SwapV2(byte[] source)
    {
        fixed (byte* p = &source[0])
        {
            var length = (source.Length & 0xFFFFFFFE); // Make even, a "bug" in accepted answer...
            ulong* pulong;
            ushort* pushort;
            while ((length & 0xFFFFFFF8) != 0) // 8 Byte blocks (while > 7)
            {
                length -= 8;
                pulong = (ulong*)(p + length);
                *pulong = ( ((0x00FF00FF00FF00FFUL) & (*pulong >> 8)) 
                          | ((0xFF00FF00FF00FF00UL) & (*pulong << 8)));
            }
            while (length != 0) // The rest
            {
                length -= 2;
                pushort = (ushort*)(p + length);
                *pushort = (ushort)((*pushort >> 8) | (*pushort << 8));
            }
        }
    }
