    public static string GetUTF8String(byte[] data)
    {
        byte[] utf8Preamble = Encoding.UTF8.GetPreamble();
        if (data.StartsWith(utf8Preamble))
        {
            return Encoding.UTF8.GetString(data, utf8Preamble.Length, data.Length - utf8Preamble.Length);
        }
        else
        {
            return Encoding.UTF8.GetString(data);
        }
    }
