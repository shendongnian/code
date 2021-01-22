    ulong countSetBits(ulong n)
    {
            int c = 0;
            while(n)
            {
                    c += 1;
                    n  = n & (n-1);
            }
            return c;
    }
    
    bool isPowerOfTwo(ulong n)
    {        
            return (countSetBits(n)==1);
    }
