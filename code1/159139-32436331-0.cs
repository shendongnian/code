        public static void RecoverPQ(
            BigInteger n,
            BigInteger e,
            BigInteger d,
            out BigInteger p,
            out BigInteger q
            )
        {
            int nBitCount = (int)(BigInteger.Log(n, 2)+1);
            // Step 1: Let k = de – 1. If k is odd, then go to Step 4
            BigInteger k = d * e - 1;
            if (k.IsEven)
            {
                // Step 2 (express k as (2^t)r, where r is the largest odd integer
                // dividing k and t >= 1)
                BigInteger r = k;
                BigInteger t = 0;
                do
                {
                    r = r / 2;
                    t = t + 1;
                } while (r.IsEven);
                // Step 3
                var rng = new RNGCryptoServiceProvider();
                bool success = false;
                BigInteger y = 0;
                for (int i = 1; i <= 100; i++) {
                    // 3a
                    byte[] randomBytes = new byte[ nBitCount / 8];
                    rng.GetBytes(randomBytes);
                    BigInteger g = new BigInteger(randomBytes);
                    // 3b
                    y = BigInteger.ModPow(g, r, n);
                    // 3c
                    if (y == 1 || y == n-1) {
                        // 3g
                        continue;
                    }
                    // 3d
                    BigInteger x;
                    for (BigInteger j = 1; j <= t; j = j + 1) {
                        // 3d1
                        x = BigInteger.ModPow(y, 2, n);
                        // 3d2
                        if (x == 1) {
                            success = true;
                            break;
                        }
                        // 3d3
                        if (x == n-1) {
                            // 3g
                            continue;
                        }
                        // 3d4
                        y = x;
                    }
                    // 3e
                    x = BigInteger.ModPow(y, 2, n);
                    if (x == 1) {
                        success = true;
                        break;
                    }
                    // 3g
                    // (loop again)
                }
                if (success) {
                    // Step 5
                    p = BigInteger.GreatestCommonDivisor((y - 1), n);
                    q = n / p;
                    return;
                }
            }
            throw new Exception("Cannot compute P and Q");
        }
