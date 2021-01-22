    public static class Utils
    {
        public static string LeftZerosFormatter(int zeros, string value)
        {
            value = value.Trim(); if (value == "") return "";
            value = new string('0', zeros) + value;
            return value.Substring(value.Length - zeros, zeros);
        }
    }
