    // From http://www.daimi.au.dk/~ivan/FastExpproject.pdf
    // Left to Right Binary Exponentiation
    public static decimal Pow(decimal x, uint y)
        {
            
            decimal A = 1m;
            BitArray e = new BitArray(BitConverter.GetBytes(y));
            int t = e.Count;
            
            for (int i = t-1; i >= 0; --i)
            {
                A *= A;
                if (e[i] == true)
                {
                    A *= x;
                }
            }
            return A;
        }
 
