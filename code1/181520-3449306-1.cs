    public string DecodeBase64(string str)
    {
       byte[] buff = Convert.FromBase64String(str);
       return System.Text.Encoding.UTF8.GetString(buff);
    }
