       private static IEnumerable<Byte> MillionBits()
       {
           var rand = new RNGCryptoServiceProvider();
           //a million bits is 125,000 bytes, so
           var bytes = new List<byte>(125000);
           for (var i = 0; i < 125; ++i)
           {
               byte[] tempBytes = new byte[1000];
               rand.GetBytes(tempBytes);
               bytes.AddRange(tempBytes);
           }
           return bytes;
       }
       private static string BytesAsString(IEnumerable<Byte> bytes)
       {
           var buffer = new StringBuilder();
           foreach (var byt in bytes)
           {
               buffer.Append(Convert.ToString(byt, 2).PadLeft(8, '0'));
           }
           return buffer.ToString();
       }
