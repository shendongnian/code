    static string Hex2Binary(string hexvalue)
    {
        StringBuilder binaryval = new StringBuilder();
        for(int i=0; i < hexvalue.Length; i++)
        {
            string byteString = hexvalue.Substring(i, 1);
            byte b = Convert.ToByte(byteString, 16);
            binaryval.Append(Convert.ToString(b, 2).PadLeft(4, '0'));
        }
        return binaryval.ToString();
    }
