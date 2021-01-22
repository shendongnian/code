    int len = strHex.Length;
    StringBuilder sb = new StringBuilder("");
    for (int i = 0; i < len; i++)
    {
        sb.Append(Convert.ToString(Convert.ToByte(strHex.Substring(i, 1), 16), 2).PadLeft(4, '0'));
    }
