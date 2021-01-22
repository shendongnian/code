    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace HsbcIntergration
    {
        internal static class CpiHashing
        {
    		<USE THE VALUE RETURNED FROM THE JAVA CODE HERE>
            private static readonly byte[] _secret = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            
            public static string ComputeHash(List<string> inputList)
            {
                return ComputeHash(inputList, _secret);
            }
    
            public static string ComputeHash(List<string> inputList, byte[] secretData)
            {
                List<string> orderedDataToHash = new List<string>(inputList);
                orderedDataToHash.Sort(StringComparer.Ordinal);
    
                StringBuilder sb = new StringBuilder();
                foreach (string s in orderedDataToHash)
                    sb.Append(s);
    
                List<byte> dataToHash = new List<byte>();
                dataToHash.AddRange(Encoding.ASCII.GetBytes(sb.ToString()));
                dataToHash.AddRange(secretData);
    
                System.Security.Cryptography.HMAC sha = System.Security.Cryptography.HMACSHA1.Create();
                sha.Key = secretData;
                return Convert.ToBase64String(sha.ComputeHash(dataToHash.ToArray(), 0, dataToHash.Count));
            }
        }
    }
