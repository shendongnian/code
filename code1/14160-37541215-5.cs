     public static string ReverseString3(string str)
        {
            char[] chars = str.ToCharArray();
            char[] rchars = new char[chars.Length];
            for (int i = 0, j = str.Length - 1; i < chars.Length; i++, j--)
            {
                rchars[j] = chars[i];
            }
            return new string(rchars);
        }
