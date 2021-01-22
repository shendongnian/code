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
            byte* pbyte = p + length - 2;
            while (pbyte > p)
            {
                *(ushort*)pbyte = (ushort)(*pbyte << 8 | *(pbyte + 1));
                pbyte -= 2;
            }
        }
    }
