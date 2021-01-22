    byte[] array = new byte[8];
    int[] shifts = new int[] { 0, 8, 16, 24, 32, 40, 48, 56 };    
    for (long index = long.MinValue; index <= long.MaxValue; index++)
    {
        for (int i = 0; i < 8; i++)
        {
            array[i] = (byte)((index >> shifts[i]) & 0xff);
        }
        // test array
    }
