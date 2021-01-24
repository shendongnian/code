    public static uint SwapBytes(uint x)
    {
       // swap adjacent 16-bit blocks
       x = (x >> 16) | (x << 16);
    
       // swap adjacent 8-bit blocks
       return ((x & 0xFF00FF00) >> 8) | ((x & 0x00FF00FF) << 8);
    }
    
    [Test("Mine", "", true)]
    public int[] Test1(byte[] input, int scale)
    {
    
    
       var result = new int[input.Length / 4];
       Buffer.BlockCopy(input, 0, result, 0, input.Length);
    
       return result.Select(x => (int)SwapBytes((uint)x))
                    .ToArray();
    
    }
