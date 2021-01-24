    public string RSABouncyEncrypt(string content)
            {
                var bytesToEncrypt = Encoding.UTF8.GetBytes(content);
                AsymmetricKeyParameter keyPair;
                using (var reader = File.OpenText(@"E:\......\public.pem"))
                {
                    keyPair = (AsymmetricKeyParameter)new Org.BouncyCastle.OpenSsl.PemReader(reader).ReadObject();
                }   
    
                var engine = new RsaEngine();
                engine.Init(true, keyPair);
    
                var encrypted = engine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);
    
                var cryptMessage = Convert.ToBase64String(encrypted);
                //Logs.Log.LogMessage("encrypted: " + cryptMessage);
                //Console.WriteLine(cryptMessage);
    
                //Decrypt before return statement to check that it has been encrypted correctly
                //RSADecrypt(cryptMessage);
                return cryptMessage;
            }
    
            public string RSADecrypt(string string64)
            {
                var bytesToDecrypt = Convert.FromBase64String(string64); // string to decrypt, base64 encoded
    
                AsymmetricCipherKeyPair keyPair;
    
                using (var reader = File.OpenText(@"E:\.....\private.pem"))
                    keyPair = (AsymmetricCipherKeyPair)new Org.BouncyCastle.OpenSsl.PemReader(reader).ReadObject();
    
                var decryptEngine = new RsaEngine();
                decryptEngine.Init(false, keyPair.Private);
    
                var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
                //Logs.Log.LogMessage("decrypted: " + decrypted);
                //Console.WriteLine(decrypted);
                return decrypted;
            }
