    using System;
    using System.Security.Cryptography;
    using System.Text;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Macs;
    using Org.BouncyCastle.Crypto.Modes;
    using Org.BouncyCastle.Crypto.Paddings;
    using Org.BouncyCastle.Crypto.Parameters;
    public sealed class Encryptor<TBlockCipher, TDigest>
        where TBlockCipher : IBlockCipher, new()
        where TDigest : IDigest, new()
    {
        private Encoding encoding;
        private IBlockCipher blockCipher;
        private BufferedBlockCipher cipher;
        private HMac mac;
        private byte[] key;
        public Encryptor(Encoding encoding, byte[] key, byte[] macKey)
        {
            this.encoding = encoding;
            this.key = key;
            this.Init(key, macKey, new Pkcs7Padding());
        }
        public Encryptor(Encoding encoding, byte[] key, byte[] macKey, IBlockCipherPadding padding)
        {
            this.encoding = encoding;
            this.key = key;
            this.Init(key, macKey, padding);
        }
        private void Init(byte[] key, byte[] macKey, IBlockCipherPadding padding)
        {
            this.blockCipher = new CbcBlockCipher(new TBlockCipher());
            this.cipher = new PaddedBufferedBlockCipher(this.blockCipher, padding);
            this.mac = new HMac(new TDigest());
            this.mac.Init(new KeyParameter(macKey));
        }
        public string Encrypt(string plain)
        {
            return Convert.ToBase64String(EncryptBytes(plain));
        }
        public byte[] EncryptBytes(string plain)
        {
            byte[] input = this.encoding.GetBytes(plain);
            var iv = this.GenerateIV();
            var cipher = this.BouncyCastleCrypto(true, input, new ParametersWithIV(new KeyParameter(key), iv));
            byte[] message = CombineArrays(iv, cipher);
            this.mac.Reset();
            this.mac.BlockUpdate(message, 0, message.Length);
            byte[] digest = new byte[this.mac.GetUnderlyingDigest().GetDigestSize()];
            this.mac.DoFinal(digest, 0);
            var result = CombineArrays(digest, message);
            return result;
        }
        public byte[] DecryptBytes(byte[] bytes)
        {
            // split the digest into component parts
            var digest = new byte[this.mac.GetUnderlyingDigest().GetDigestSize()];
            var message = new byte[bytes.Length - digest.Length];
            var iv = new byte[this.blockCipher.GetBlockSize()];
            var cipher = new byte[message.Length - iv.Length];
            Buffer.BlockCopy(bytes, 0, digest, 0, digest.Length);
            Buffer.BlockCopy(bytes, digest.Length, message, 0, message.Length);
            if (!IsValidHMac(digest, message))
            {
                throw new CryptoException();
            }
            Buffer.BlockCopy(message, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(message, iv.Length, cipher, 0, cipher.Length);
            byte[] result = this.BouncyCastleCrypto(false, cipher, new ParametersWithIV(new KeyParameter(key), iv));
            return result;
        }
        public string Decrypt(byte[] bytes)
        {
            return this.encoding.GetString(DecryptBytes(bytes));
        }
        public string Decrypt(string cipher)
        {
            return this.Decrypt(Convert.FromBase64String(cipher));
        }
        private bool IsValidHMac(byte[] digest, byte[] message)
        {
            this.mac.Reset();
            this.mac.BlockUpdate(message, 0, message.Length);
            byte[] computed = new byte[this.mac.GetUnderlyingDigest().GetDigestSize()];
            this.mac.DoFinal(computed, 0);
            return AreEqual(digest,computed);
        }
        private static bool AreEqual(byte [] digest, byte[] computed)
        {
            if(digest.Length != computed.Length)
            {
                return false;
            }
            int result = 0;
            for (int i = 0; i < digest.Length; i++)
            {
                result |= digest[i] ^ computed[i];
            }
            return result == 0;
        }
        private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input, ICipherParameters parameters)
        {
            try
            {
                cipher.Init(forEncrypt, parameters);
                return this.cipher.DoFinal(input);
            }
            catch (CryptoException)
            {
                throw;
            }
        }
        private byte[] GenerateIV()
        {
            using (var provider = new RNGCryptoServiceProvider())
            {
                // 1st block
                byte[] result = new byte[this.blockCipher.GetBlockSize()];
                provider.GetBytes(result);
                return result;
            }
        }
        private static byte[] CombineArrays(byte[] source1, byte[] source2)
        {
            byte[] result = new byte[source1.Length + source2.Length];
            Buffer.BlockCopy(source1, 0, result, 0, source1.Length);
            Buffer.BlockCopy(source2, 0, result, source1.Length, source2.Length);
            return result;
        }
    }
