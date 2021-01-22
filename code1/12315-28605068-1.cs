    public string DecryptString(string inputString)
    {
    MemoryStream memStream = null;
    try
    {
        byte[] key = { };
        byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
        string encryptKey = "aXb2uy4z";
        key = Encoding.UTF8.GetBytes(encryptKey);
        byte[] byteInput = new byte[inputString.Length];
        byteInput = Convert.FromBase64String(inputString);
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        memStream = new MemoryStream();
        ICryptoTransform transform = provider.CreateDecryptor(key, IV);
        CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
        cryptoStream.Write(byteInput, 0, byteInput.Length);
        cryptoStream.FlushFinalBlock();
    }
    catch (Exception ex)
    {
        Response.Write(ex.Message);
    }
 
    Encoding encoding1 = Encoding.UTF8;
    return encoding1.GetString(memStream.ToArray());
}
