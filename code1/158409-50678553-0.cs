    static string ToCodeString(string s)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
    
            char c;
            int i = 0;
    
            while (i < s.Length)
            {
                c = (char)s[i];
    
                if (c == 34 || c == 92 || c == 93) //speechmarks backslash
                {
                    sb.Append("\\" + c);
                }
                else if (c == 13)
                {
                    sb.Append("\\r");
                }
                else if (c == 10)
                {
                    sb.Append("\\n");
                }
                else if (c == 0)
                {
                    sb.Append("\\0");
                }
                else if (c == 7)
                {
                    sb.Append("\\a");
                }
                else if (c == 8)
                {
                    sb.Append("\\b");
                }
                else if (c == 12)
                {
                    sb.Append("\\f");
                }
                else if (c == 9)
                {
                    sb.Append("\\t");
                }
                else if (c == 11)
                {
                    sb.Append("\\v");
                }
                else if (c >= 32 && c <= 127) //ascii
                {
                    sb.Append(c);
                }
                //else <-- if you want to represent unicode in ascii
                //{
                //    sb.Append(string.Format(@"\u{0:x4}", (int)c));
                //}
                else
                {
                    sb.Append(c);
                }
                i++;
            }
    
            return sb.ToString();
    }
