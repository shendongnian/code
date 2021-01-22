    public static void AssignNewKey(){
        RSA rsa = new RSACryptoServiceProvider(2048); // Generate a new 2048 bit RSA key
    
        string publicPrivateKeyXML = rsa.ToXmlString(true);
        string publicOnlyKeyXML = rsa.ToXmlString(false);
        // do stuff with keys...
    }
