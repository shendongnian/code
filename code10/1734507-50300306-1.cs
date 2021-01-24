    public static string Arabic1256ToUtf8(string data)
    {
        var latin = Encoding.GetEncoding("ISO-8859-1");
        var bytes = latin.GetBytes(data); // get the bytes for your ANSI string
    
        var arabic = Encoding.GetEncoding("Windows-1256"); // decode it using the correct encoding
        return arabic.GetString(bytes);
    }
