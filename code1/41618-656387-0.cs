    public static string base64Decode(string data)
    {
        byte[] binary = Convert.FromBaseString(data);
        return Encoding.Default.GetString(binary);
    }
