    static public string ToPrintableString(this byte[] bytes)
    {
        return Encoding.ASCII.GetString
               (
                  bytes.Select(x => x < 0x20 || x > 0x7E ? (byte)'.' : x)
                       .ToArray()
               );
    }
