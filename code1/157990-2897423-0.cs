    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                String encryptedString;
               
    
                for (int j = 0; j < 1000; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        encryptedString = Encrypt(String.Format("test string {0} {1}", j, i), "key");
                    }
                    Console.WriteLine("j = {0}", j);
                }
    
                Console.WriteLine("Finished");
                Console.ReadLine();
    
            }
    
            public static string Encrypt(string plainText, string key)
            {
                //Set up the encryption objects
                byte[] encryptedBytes = null;
                using (AesCryptoServiceProvider acsp = GetProvider(Encoding.UTF8.GetBytes(key)))
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(plainText);
                    using (ICryptoTransform ictE = acsp.CreateEncryptor())
                    {
                        //Set up stream to contain the encryption
                        using (MemoryStream msS = new MemoryStream())
                        {
                            //Perform the encrpytion, storing output into the stream
                            using (CryptoStream csS = new CryptoStream(msS, ictE, CryptoStreamMode.Write))
                            {
                                csS.Write(sourceBytes, 0, sourceBytes.Length);
                                csS.FlushFinalBlock();
    
                                //sourceBytes are now encrypted as an array of secure bytes
                                encryptedBytes = msS.ToArray(); //.ToArray() is important, don't mess with the buffer
    
                                csS.Close();
                            }
    
                            msS.Close();
                        }
                    }
    
                    acsp.Clear();
                }
    
                //return the encrypted bytes as a BASE64 encoded string
                return Convert.ToBase64String(encryptedBytes);
            }
            private static AesCryptoServiceProvider GetProvider(byte[] key)
            {
                AesCryptoServiceProvider result = new AesCryptoServiceProvider();
                result.BlockSize = 128;
                result.KeySize = 256;
                result.Mode = CipherMode.CBC;
                result.Padding = PaddingMode.PKCS7;
    
                result.GenerateIV();
                result.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    
                byte[] RealKey = GetKey(key, result);
                result.Key = RealKey;
                // result.IV = RealKey;
                return result;
            }
    
            private static byte[] GetKey(byte[] suggestedKey, SymmetricAlgorithm p)
            {
                byte[] kRaw = suggestedKey;
                List<byte> kList = new List<byte>();
    
                for (int i = 0; i < p.LegalKeySizes[0].MaxSize; i += 8)
                {
                    kList.Add(kRaw[(i / 8) % kRaw.Length]);
                }
                byte[] k = kList.ToArray();
                return k;
            }
    
        }
    }
