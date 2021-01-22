    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace SimpleXOREncryption
    {    
        public static class EncryptorDecryptor
        {
            public static string EncryptDecrypt(string textToEncrypt, int key)
            {            
                StringBuilder inSb = new StringBuilder(textToEncrypt);
                StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
                char c;
                for (int i = 0; i < textToEncrypt.Length; i++)
                {
                    c = inSb[i];
                    c = (char)(c ^ key);
                    outSb.Append(c);
                }
                return outSb.ToString();
            }   
        }
    }
