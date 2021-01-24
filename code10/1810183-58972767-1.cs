    static void Main(string[] args)
    {
       CryptoHelper.InitDESKeys();
       string strText==Strin.Empty();
       strText="Text to decrypt";
       string encryptedText=CryptoHelper.DESEncrypt(strText);
       string decryptedText=Strin.Empty();
       decryptedText=CryptoHelper.DESDecrypt(strText);
    }
