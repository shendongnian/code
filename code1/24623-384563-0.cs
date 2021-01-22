    using System;
    using System.Security.Cryptography;
    
    namespace Agnus.Cipher
    {
        public class RSA : IDisposable
        {
            private RSACryptoServiceProvider rSAProviderThis;
            private RSACryptoServiceProvider rSAProviderOther = null;
    
            public string PublicKey
            {
                get { return rSAProviderThis.ToXmlString(false); }
            }
    
            public RSA()
            {
                rSAProviderThis = new RSACryptoServiceProvider { PersistKeyInCsp = true }; 
            }
    
            public void InitializeRSAProviderOther(string parameters)
            {
                rSAProviderOther.FromXmlString(parameters);
            }
           
            public byte[] Encrypt(byte[] plaintextBytes)
            {
                    return rSAProviderThis.Encrypt(plaintextBytes, true);
            }
            public string  Decrypt(byte[] ciphertextBytes)
            {
                try
                {
                    return Convert.ToBase64String( rSAProviderThis.Decrypt(ciphertextBytes, true));
                }
                catch (CryptographicException ex)
                {
                    Console.WriteLine("Unable to decrypt: " + ex.Message + " " + ex.StackTrace);
                }
                finally
                {
                    this.Dispose();
                }
                return string.Empty;
            }
            public string SignData(byte[] ciphertextBytes)
            {
                string  signature = GenerateSignature(ciphertextBytes, rSAProviderThis);
                return signature;
            }
    
            private string GenerateSignature(byte[] ciphertextBytes, RSACryptoServiceProvider provider)
            {
                using (SHA1Managed SHA1 = new SHA1Managed())
                {
                    byte[] hash = SHA1.ComputeHash(ciphertextBytes);
                    string signature = Convert.ToBase64String(provider.SignHash(hash, CryptoConfig.MapNameToOID("SHA1")));
                    return signature;
                }
                
            }
    
            public string  VerifySignature(byte[] ciphertextBytes, string parameters, string signatureToVerify)
            {
                InitializeRSAProviderOther(parameters);
                string actualSignature = GenerateSignature(ciphertextBytes, rSAProviderOther);
                if (actualSignature.Equals(signatureToVerify))
                {
                    //verification successful
                    string decryptedData = this.Decrypt(ciphertextBytes);
                    return decryptedData;
                    //decryptedData is a symmetric key
                }
                else
                {
                    //verification unsuccessful
                    //end session
                }
                return string.Empty;
            }
    
            #region IDisposable Members
    
            public void Dispose()
            {
                if (rSAProviderOther != null)
                {
                    rSAProviderOther.Clear();
                }
                rSAProviderThis.Clear();
                GC.SuppressFinalize(this);
            }
            #endregion
        }
    }
