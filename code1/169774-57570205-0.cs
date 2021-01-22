    public static class StringHelper
        {
            public static string ToHexString(this string str)
            {
                byte[] bytes = str.IsUnicode() ? Encoding.UTF8.GetBytes(str) : Encoding.Default.GetBytes(str);
                
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
    
            public static bool IsUnicode(this string input)
            {
                const int maxAnsiCode = 255;
    
                return input.Any(c => c > maxAnsiCode);
            }
    }
