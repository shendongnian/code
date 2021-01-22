    byte prefix = 0;
    int prefixLength = 0;
    for(byte mask = 0x80; mask > 0; mask >> 1)
    {
        if (byte1 & mask == byte2 & mask)
        {
            prefix << 1;
            if (byte1 & mask == mask)
                prefix |= 1;
            ++prefixLength;
        }
    }
    System.Console.WriteLine("Common prefix is " + Convert.ToString(prefix, 2) +
                             ", length " + prefixLength);
