    static string ToBinary(int n)
    {
        int j = 0;
        char[] output = new char[32];
    
        if (n == 0)
            output[j++] = '0';
        else
        {
            int checkBit = 1 << 30;
            bool skipInitialZeros = true;
            // Check the sign bit separately, as 1<<31 will cause
            // +ve integer overflow
            if ((n & int.MinValue) == int.MinValue)
            {
                output[j++] = '1';
                skipInitialZeros = false;
            }
    
            for (int i = 0; i < 31; i++, checkBit >>= 1)
            {
                if ((n & checkBit) == 0)
                {
                    if (skipInitialZeros)
                        continue;
                    else
                        output[j++] = '0';
                }
                else
                {
                    skipInitialZeros = false;
                    output[j++] = '1';
                }
            }
        }
    
        return new string(output, 0, j);
    }
