    public static class StringExtensions
    {
        public static string SafeSubstring(this string input, int startIndex, int length)
        {
            // Todo: Check that startIndex + length does not cause an arithmetic overflow
            if (input.Length > (startIndex + length))
            {
                return input.Substring(startIndex, length);
            }
            else
            {
                if (input.Length > startIndex)
                {
                    return input.Substring(startIndex);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
