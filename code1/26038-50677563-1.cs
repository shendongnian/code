    public static class Utils
    {
        public static string LeftZerosFormatter(int zeros, int val)
        {
            string valstr = val.ToString();
            valstr = new string('0', zeros) + valstr;
            return valstr.Substring(valstr.Length - zeros, zeros);
        }
    }
