        static public String EncryptString(String message)
        {
            String sRet = "";
            RijndaelManaged rj = new RijndaelManaged();
            try
            {
                rj.Key = Key;
                rj.IV = IV;
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(message);
                    }
                }
                byte[] encoded = ms.ToArray();
                sRet = Convert.ToBase64String(encoded);
            }
            finally
            {
                rj.Clear();
            }
            return sRet;
        }
        static public String DecryptString(String cypher)
        {
            String sRet = "";
            RijndaelManaged rj = new RijndaelManaged();
            try
            {
                byte[] message = Convert.FromBase64String(cypher);
                rj.Key = Key;
                rj.IV = IV;
                MemoryStream ms = new MemoryStream(message);
                using (CryptoStream cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        sRet = sr.ReadToEnd();
                    }
                }
            }
            finally
            {
                rj.Clear();
            }
            return sRet;
        }</code></pre>
Key and IV are static byte[] contained in the class.
