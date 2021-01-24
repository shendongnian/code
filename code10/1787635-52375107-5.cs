    internal static class StringUtils
    {
        public static string ToCamelCase(string s)
        {
            if (!string.IsNullOrEmpty(s) && char.IsUpper(s[0]))
            {
                char[] array = s.ToCharArray();
                for (int i = 0; i < array.Length && (i != 1 || char.IsUpper(array[i])); i++)
                {
                    bool flag = i + 1 < array.Length;
                    if ((i > 0 & flag) && !char.IsUpper(array[i + 1])) // << Missing check for a number.
                    {
                        break;
                    }
                    char c = char.ToLower(array[i], CultureInfo.InvariantCulture);
                    array[i] = c;
                }
                return new string(array);
            }
            return s;
        }
    }
