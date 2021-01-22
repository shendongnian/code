     public class Rijndael
    {
        private byte[] key;
        private readonly byte[] vector = { 255, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        ICryptoTransform EnkValue, DekValue;
        public Rijndael(byte[] key)
        {
            this.key = key;
            RijndaelManaged rm = new RijndaelManaged();
            rm.Padding = PaddingMode.PKCS7;
            EnkValue = rm.CreateEncryptor(key, vector);
            DekValue = rm.CreateDecryptor(key, vector);
        }
        public byte[] Encrypt(byte[] byte)
        {
            byte[] enkByte= byte;
            byte[] enkNewByte;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, EnkValue, CryptoStreamMode.Write))
                {
                    cs.Write(enkByte, 0, enkByte.Length);
                    cs.FlushFinalBlock();
                    ms.Position = 0;
                    enkNewByte= new byte[ms.Length];
                    ms.Read(enkNewByte, 0, enkNewByte.Length);
                }
            }
            return enkNeyByte;
        }
        public byte[] Dekrypt(byte[] enkByte)
        {
            byte[] dekByte;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, DekValue, CryptoStreamMode.Write))
                {
                    cs.Write(enkByte, 0, enkByte.Length);
                    cs.FlushFinalBlock();
                    ms.Position = 0;
                    dekByte= new byte[ms.Length];
                    ms.Read(dekByte, 0, dekByte.Length);
                }
            }
            return dekByte;
        }
    }
