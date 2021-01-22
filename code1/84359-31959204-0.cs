    public static string GetUniqueKey(int size = 6, string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
    {
        using (var crypto = new RNGCryptoServiceProvider())
        {
            var data = new byte[size];
    
            // If chars.Length isn't a power of 2 then there is a bias if
            // we simply use the modulus operator. The first characters of
            // chars will be more probable than the last ones.
    
            // buffer used if we encounter an unusable random byte. We will
            // regenerate it in this buffer
            byte[] smallBuffer = null;
    
            // Maximum random number that can be used without introducing a
            // bias
            int maxRandom = byte.MaxValue - ((byte.MaxValue + 1) % chars.Length);
    
            crypto.GetBytes(data);
    
            var result = new char[size];
    
            for (int i = 0; i < size; i++)
            {
                byte v = data[i];
    
                while (v > maxRandom)
                {
                    if (smallBuffer == null)
                    {
                        smallBuffer = new byte[1];
                    }
    
                    crypto.GetBytes(smallBuffer);
                    v = smallBuffer[0];
                }
    
                result[i] = chars[v % chars.Length];
            }
    
            return new string(result);
        }
    }
