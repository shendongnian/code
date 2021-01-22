    public static string encode(string ascii)
    {
        if (ascii == null)
        {
            return null;
        }
        else
        {
            char[] arrChars = ascii.ToCharArray();
            string binary = "";
            string divider = ".";
            foreach (char ch in arrChars)
            {
                binary += Convert.ToString(Convert.ToInt32(ch), 2) + divider;
            }
            return binary;
        }
    }
     public static string decode(string binary)
    {
        if (binary == null)
        {
            return null;
        }
        else
        {
            try
            {
                string[] arrStrings = binary.Trim('.').Split('.');
                string ascii = "";
                foreach (string s in arrStrings)
                {
                    ascii += Convert.ToChar(Convert.ToInt32(s, 2));
                }
                return ascii;
            }
            catch (FormatException)
            {
                throw new FormatException("SECURITY ALERT! You cannot access a page by entering its URL.");
            }
        }
    }
}
