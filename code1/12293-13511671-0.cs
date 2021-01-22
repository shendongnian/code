    public sealed class Encryptor<T> where T : IBlockCipher, new()
    {
        private readonly Encoding encoding;
        private readonly IBlockCipher blockCipher;
        private BufferedBlockCipher cipher;
        public Encryptor(Encoding encoding)
        {
            this.blockCipher = new T();
            this.encoding = encoding;
        }
        public string Encrypt(string plain, byte[] key)
        {
            byte[] input = this.encoding.GetBytes(plain);
            if ((input.Length % this.blockCipher.GetBlockSize()) > 0)
            {
                byte[] newResult = new byte[(input.Length + (this.blockCipher.GetBlockSize() - (input.Length % this.blockCipher.GetBlockSize())))];
                input.CopyTo(newResult, 0);
                input = newResult;
            }
            byte[] result = this.BouncyCastleCrypto(true, input, key);
            return Convert.ToBase64String(result);
        }
        public string Decrypt(string cipher, byte[] key)
        {
            byte[] result = this.BouncyCastleCrypto(false, Convert.FromBase64String(cipher), key);
            return this.encoding.GetString(result);
        }
        private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input, byte[] key)
        {
            try
            {
                this.cipher = new BufferedBlockCipher(this.blockCipher);
                this.cipher.Init(forEncrypt, new KeyParameter(key));
                return this.cipher.DoFinal(input);
            }
            catch (CryptoException)
            {
                throw;
            }
        }
    }
