    public static String execute(String content)
    {
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] plainbytes = System.Text.Encoding.ASCII.GetBytes(content);
        byte[] cipherbytes = rsa.Encrypt(plainbytes, false);
        SoapHexBinary hexBinary = new SoapHexBinary(cipherbytes);
        String cipherHex = hexBinary.ToString();
        // This String is used on java side to decrypt
        Console.WriteLine("CIPHER HEX: " + cipherHex);
        return cipherHex;
    }
