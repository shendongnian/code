    private byte[] HexaToBytes(string str)
    {
        byte[] byteArr = new byte[str.Length / 2];
        for (int i = 0; i < byteArr.Length; i++)
        {
            string s = str.Substring(i * 2, 2);
            byteArr[i] = Convert.ToByte(s, 16);
        }
        return byteArr;
    }
