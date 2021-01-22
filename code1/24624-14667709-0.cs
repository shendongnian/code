    namespace Crypto
    {
    using System;
    using System.Security.Cryptography;
    class RSACry
    {
        public enum Algorithms
        {
            DES,
            TDES,
            RC2,
            RDAEL
        };
        public string Encrypt(string xmlkeystring, Algorithms typo, string datatoencrypt)
        {
            RSA rsaer = RSACry.ReadKeyString(xmlkeystring);
            byte[] result = RSACry.EncryptIt(rsaer, typo, datatoencrypt);
            return System.Convert.ToBase64String(result);
        }
        public string Decrypt(string xmlkeystring,Algorithms typo,string datatodecrypt)
        {
            RSA rsaer = RSACry.ReadKeyString(xmlkeystring);
            byte[] result =RSACry.DecryptIt(rsaer, typo, datatodecrypt);
            return System.Text.Encoding.UTF8.GetString(result);
        }
        public static byte[] EncryptIt(RSA rsaer, Algorithms typo, string datatoencrypt)
        {
            byte[] result = null;
            try
            {
                byte[] plainbytes = System.Text.Encoding.UTF8.GetBytes(datatoencrypt);
                SymmetricAlgorithm sa = SymmetricAlgorithm.Create(RSACry.GetAlgorithmName(typo));
                ICryptoTransform ct = sa.CreateEncryptor();
                byte[] encrypt = ct.TransformFinalBlock(plainbytes, 0, plainbytes.Length);
                RSAPKCS1KeyExchangeFormatter fmt = new RSAPKCS1KeyExchangeFormatter(rsaer);
                byte[] keyex = fmt.CreateKeyExchange(sa.Key);
                //--return the key exchange, the IV (public) and encrypted data 
                result = new byte[keyex.Length + sa.IV.Length + encrypt.Length];
                Buffer.BlockCopy(keyex, 0, result, 0, keyex.Length);
                Buffer.BlockCopy(sa.IV, 0, result, keyex.Length, sa.IV.Length);
                Buffer.BlockCopy(encrypt, 0, result, keyex.Length + sa.IV.Length, encrypt.Length);
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Unable to crypt: " + ex.Message);
            }
            return result;
        }
        public static byte[] DecryptIt(RSA rsaer, Algorithms typo, string datatodecrypt)
        {
            byte[] result = null;
            try
            {
                byte[] encrbytes = System.Convert.FromBase64String(datatodecrypt);
                SymmetricAlgorithm sa = SymmetricAlgorithm.Create(RSACry.GetAlgorithmName(typo));
                byte[] keyex = new byte[(rsaer.KeySize >> 3) - 1];
                Buffer.BlockCopy(encrbytes, 0, keyex, 0, keyex.Length);
                RSAPKCS1KeyExchangeDeformatter def = new RSAPKCS1KeyExchangeDeformatter(rsaer);
                byte[] key = def.DecryptKeyExchange(keyex);
                byte[] iv = new byte[sa.IV.Length - 1];
                Buffer.BlockCopy(encrbytes, keyex.Length, iv, 0, iv.Length);
                ICryptoTransform ct = sa.CreateDecryptor(key, iv);
                result = ct.TransformFinalBlock(encrbytes, keyex.Length + iv.Length, (encrbytes.Length - 1) - (keyex.Length + iv.Length));
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Unable to decrypt: " + ex.Message);
            }
            return result;
        }
        public static string GetAlgorithmName(Algorithms typo)
        {
            string algtype = String.Empty;
            switch(typo)
            {
                case Algorithms.DES:
                    algtype = "DES";
                    break;
                case Algorithms.RC2:
                    algtype = "RC2";
                    break;
                case Algorithms.RDAEL:
                    algtype = "Rijndael";
                    break;
                case Algorithms.TDES:
                    algtype = "TripleDES";
                    break;
                default:
                    algtype = "Rijndael";
                    break;
            }
            return algtype;
        }
        public static RSA ReadKeyString(string xmlkeystring)
        {
            RSA rsaer = null;
            try
            {
                if (String.IsNullOrEmpty(xmlkeystring))
                { throw new Exception("Key is not specified"); }
                rsaer = RSA.Create();
                rsaer.FromXmlString(xmlkeystring);
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Unable to load key :"+ex.Message);
            }
            return rsaer;
        }
    }
    }
 
