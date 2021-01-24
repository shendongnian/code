    public static string RemoveNonNumeric(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
                if (Char.IsNumber(s[i]) || s[i] == '.')
                    sb.Append(s[i]);
            return sb.ToString();
        }
