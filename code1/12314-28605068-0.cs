    public string EncryptString(string inputString)
    {
    MemoryStream memStream = null;
    try
    {
        byte[] key = { };
        byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
        string encryptKey = "aXb2uy4z";
        key = Encoding.UTF8.GetBytes(encryptKey);
        byte[] byteInput = Encoding.UTF8.GetBytes(inputString);
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        memStream = new MemoryStream();
        ICryptoTransform transform = provider.CreateEncryptor(key, IV);
        CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
        cryptoStream.Write(byteInput, 0, byteInput.Length);
        cryptoStream.FlushFinalBlock();
          
    }
    catch (Exception ex)
    {
        Response.Write(ex.Message);
    }
    return Convert.ToBase64String(memStream.ToArray());
    }
