    static public string ConvertFromBytes(byte[] input)
    {
        return Encoding.ASCII.GetString
               (
                  input.Select(x => x < 0x20 || x > 0x7E ? (byte)'.' : x)
                       .ToArray()
               );
    }
