    static unsafe void SwapV2(byte[] source)
    {
        fixed (byte* psource = source)
        {
            var length = (source.Length & 0xFFFFFFFE);
            while (length > 7)
            {
                length -= 8;
                ulong* pulong = (ulong*)(psource + length);
                *pulong = ( ((*pulong >> 8) & 0x00FF00FF00FF00FFUL)
                          | ((*pulong << 8) & 0xFF00FF00FF00FF00UL));
            }
            if(length > 3)
            {
                length -= 4;
                uint* puint = (uint*)(psource + length);
                *puint = ( ((*puint >> 8) & 0x00FF00FFU)
                         | ((*puint << 8) & 0xFF00FF00U));
            }
            if(length > 1)
            {
                ushort* pushort = (ushort*)psource;
                *pushort = (ushort) ( (*pushort >> 8)
                                    | (*pushort << 8));
            }
        }
    }
