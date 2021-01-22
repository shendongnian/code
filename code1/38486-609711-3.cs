    public static decimal Next(decimal max)
    {
        // Create a int array to hold the random values.
        Byte[] bytes= new Byte[] { 0,0,0,0 };
        
        RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();
    
        // Fill the array with a random value.
        Gen.GetBytes(bytes);
        bytes[3] %= 29; // this must be between 0 and 28 (inclusive)
        decimal d = new decimal( (int)bytes[0], (int)bytes[1], (int)bytes[2], false, bytes[3]);
            return d % (max+1);
        }
