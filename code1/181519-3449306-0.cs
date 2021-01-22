    public string DecodeBase64(string a)
    {
       byte[] decbuff = Convert.FromBase64String(str);
       return System.Text.Encoding.UTF8.GetString(decbuff);
    }
