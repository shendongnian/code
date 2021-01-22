    decimal d = 12.3456789m;
    
    // decimal to byte[]
    byte[] bytes = new byte[16];
    Buffer.BlockCopy(decimal.GetBits(d), 0, bytes, 0, 16);
    // byte[] to decimal
    int[] bits = new int[4];
    Buffer.BlockCopy(bytes, 0, bits, 0, 16);
    Console.WriteLine(new decimal(bits));  // 12.3456789
