    private byte[] HexaToBytes(string str)
    {
        byte[] data = new byte[str.Length / 2];
        for (int i = 0; i < data.Length; i++)
        {
            string s = str.Substring(i * 2, 2);
            data[i] = Convert.ToByte(s, 16);
        }
        return data;
    }
