    public static byte[] ConvertToByteArray(this string s)
    {
        string tmp = s.Replace("0x","").Replace("-","");
        tmp = Regex.Replace(tmp, ".{2}", "$0-");
        return tmp.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
    }
