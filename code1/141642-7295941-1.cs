    class CEncryption
    {
        public static string Encrypt(string strIn, string strKey)
        {
            string sbOut = String.Empty;
            for (int i = 0; i < strIn.Length; i++)
            {
                sbOut += String.Format("{0:00}", strIn[i] ^ strKey[i % strKey.Length]);
            }
            return sbOut;
        }
        public static string Decrypt(string strIn, string strKey)
        {
            string sbOut = String.Empty;
            for (int i = 0; i < strIn.Length; i += 2)
            {
                byte code = Convert.ToByte(strIn.Substring(i, 2));
                sbOut += (char)(code ^ strKey[(i/2) % strKey.Length]);
            }
            return sbOut;
        }
     }
