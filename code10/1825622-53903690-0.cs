    public static void Main()
    {
        var bytes = StringToByteArray("0030003100320033");
        var decoded = System.Text.Encoding.BigEndianUnicode.GetString(bytes);
        Console.WriteLine(decoded);   // gives "0123"
    }
    // https://stackoverflow.com/a/311179/1149773
    public static byte[] StringToByteArray(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < hex.Length; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        return bytes;
    }
