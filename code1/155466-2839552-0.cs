    static byte[] UnpackHex(string hexvalue)
    {
            if (hexvalue.Length % 2 != 0)
                    hexvalue = "0" + hexvalue;
            int len = hexvalue.Length / 2;
            byte[] bytes = new byte[len];
            for(int i = 0; i < len; i++)
            {
                    string byteString = hexvalue.Substring(2 * i, 2);
                    bytes[i] = Convert.ToByte(byteString, 16);
            }
            return bytes;
    }
