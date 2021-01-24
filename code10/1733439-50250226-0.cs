    public static unsafe void XOr64(byte[] oldBlock, byte[] newBlock)
    {
        // First XOR as many 64-bit blocks as possible, for the sake of speed
        fixed (byte* byteA = oldBlock)
        fixed (byte* byteB = newBlock)
        {
            long* ppA = (long*) byteA;
            long* ppB = (long*) byteB;
            int chunks = oldBlock.Length / 8;
            for (int p = 0; p < chunks; p++)
            {
                *ppA ^= *ppB;
                ppA++;
                ppB++;
            }
        }
        // Now cover any remaining bytes one byte at a time. We've
        // already handled chunks * 8 bytes, so start there.
        for (int index = chunks * 8; index < oldBlock.Length; index++)
        {
            oldBlock[index] ^= newBlock[index];
        }
    }
