    public string RsaEncryptWithPublic(string clearText, string publicKey)
        {
            //  analogue of Java:
            //  Cipher rsa = Cipher.getInstance("RSA/ECB/nopadding");
            try
            {
                var bytesToEncrypt = Encoding.ASCII.GetBytes(clearText);
                var encryptEngine = new RsaEngine(); // new Pkcs1Encoding (new RsaEngine());
              
                using (var txtreader = new StringReader("-----BEGIN PUBLIC KEY-----\n" + publicKey+ "\n-----END PUBLIC KEY-----"))
                {
                    var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();
                    encryptEngine.Init(true, keyParameter);
                }
                var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
                return encrypted;
            }
            catch 
            {
                
                return "";
            }
        }
