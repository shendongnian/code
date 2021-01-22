    static void Main()
    {
        byte[] data = FromHex("47-61-74-65-77-61-79-53-65-72-76-65-72");
        string s = Encoding.ASCII.GetString(data); // GatewayServer
    }
    public static byte[] FromHex(string hex)
    {
        hex = hex.Replace("-", "");
        byte[] raw = new byte[hex.Length / 2];
        for (int i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return raw;
    }
