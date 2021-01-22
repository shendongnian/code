    using System.Security.Cryptography;
    public static Int64 NextInt64()
    {
       var bytes = new byte[sizeof(Int64)];    
       RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();
       Gen.GetBytes(bytes);    
       return BitConverter.ToInt64(bytes , 0);        
    }
