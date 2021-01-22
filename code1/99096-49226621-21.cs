    static unsafe void SwapV2(byte[] source)
    {
        fixed (byte* p = source)
        {
            // Make length even, a "bug" in accepted answer...
            var length = (source.Length & 0xFFFFFFFE);
            // 8 Byte blocks at once
            while (length > 7)
            {
                length -= 8;
                ulong* pulong = (ulong*)(p + length);
                *pulong = ( ((0x00FF00FF00FF00FFUL) & (*pulong >> 8))
                          | ((0xFF00FF00FF00FF00UL) & (*pulong << 8)));
            }
            // The rest in 2 byte blocks
            while (length != 0)
            {
                length -= 2;
                ushort* pushort = (ushort*)(p + length);
                *pushort = (ushort)((*pushort >> 8) | (*pushort << 8));
            }
        }
    }
