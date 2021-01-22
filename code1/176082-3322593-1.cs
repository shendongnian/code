    public byte[] Encode(int[,] input)
    {
        int d0 = input.GetLength(0), d1 = input.GetLength(1);
        byte[] raw = new byte[((d0 * d1) + 2) * 4];
        Buffer.BlockCopy(BitConverter.GetBytes(d0), 0, raw, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(d1), 0, raw, 4, 4);
        int offset = 8;
        for(int i0 = 0 ; i0 < d0 ; i0++)
            for (int i1 = 0; i1 < d1; i1++)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(input[i0,i1]), 0,
                      raw, offset, 4);
                offset += 4;
            }
        return raw;
    }
