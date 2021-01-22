    private static RSAParameters RecoverRSAParameters(BigInteger n, BigInteger e, BigInteger d)
    {
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            BigInteger k = d * e - 1;
            if (!k.IsEven)
            {
                throw new InvalidOperationException("d*e - 1 is odd");
            }
            BigInteger two = 2;
            BigInteger t = BigInteger.One;
            BigInteger r = k / two;
            while (r.IsEven)
            {
                t++;
                r /= two;
            }
            byte[] rndBuf = n.ToByteArray();
            if (rndBuf[rndBuf.Length - 1] == 0)
            {
                rndBuf = new byte[rndBuf.Length - 1];
            }
            BigInteger nMinusOne = n - BigInteger.One;
            bool cracked = false;
            BigInteger y = BigInteger.Zero;
            for (int i = 0; i < 100 && !cracked; i++)
            {
                BigInteger g;
                do
                {
                    rng.GetBytes(rndBuf);
                    g = GetBigInteger(rndBuf);
                }
                while (g >= n);
                y = BigInteger.ModPow(g, r, n);
                if (y.IsOne || y == nMinusOne)
                {
                    i--;
                    continue;
                }
                for (BigInteger j = BigInteger.One; j < t; j++)
                {
                    BigInteger x = BigInteger.ModPow(y, two, n);
                    if (x.IsOne)
                    {
                        cracked = true;
                        break;
                    }
                    if (x == nMinusOne)
                    {
                        break;
                    }
                    y = x;
                }
            }
            if (!cracked)
            {
                throw new InvalidOperationException("Prime factors not found");
            }
            BigInteger p = BigInteger.GreatestCommonDivisor(y - BigInteger.One, n);
            BigInteger q = n / p;
            BigInteger dp = d % (p - BigInteger.One);
            BigInteger dq = d % (q - BigInteger.One);
            BigInteger inverseQ = ModInverse(q, p);
            int modLen = rndBuf.Length;
            int halfModLen = (modLen + 1) / 2;
            return new RSAParameters
            {
                Modulus = GetBytes(n, modLen),
                Exponent = GetBytes(e, -1),
                D = GetBytes(d, modLen),
                P = GetBytes(p, halfModLen),
                Q = GetBytes(q, halfModLen),
                DP = GetBytes(dp, halfModLen),
                DQ = GetBytes(dq, halfModLen),
                InverseQ = GetBytes(inverseQ, halfModLen),
            };
        }
    }
