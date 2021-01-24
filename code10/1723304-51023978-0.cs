    private readonly string _apiKey = "123456"; 
    private readonly string _apiSecret = "123456"; 
    private long nonce = DateTime.Now.Ticks;
    private string CreateSignature()
    {
        //string msg = string.Format("{0}{1}{2}", _apiKey);
        return ByteArrayToString(SignHMACSHA512(_apiSecret, StringToByteArray(_apiKey))).ToUpper();
    }
    private static byte[] SignHMACSHA512(String key, byte[] data)
    {
        HMACSHA512 hashMaker = new HMACSHA512(Encoding.ASCII.GetBytes(key));
        return hashMaker.ComputeHash(data);
    }
    private static byte[] StringToByteArray(string str)
    {
        return System.Text.Encoding.ASCII.GetBytes(str);
    }
    private static string ByteArrayToString(byte[] hash)  //rimuove - e converte in bite
    {
        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }
