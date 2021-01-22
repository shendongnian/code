    public static class StringExtensions
    {
        public static string SafeSubstring(this string input, int startIndex, int length, string suffix)
        {
            // Todo: Check that startIndex + length does not cause an arithmetic overflow - not that this is likely, but still...
            if (input.Length >= (startIndex + length))
            {
                if (suffix == null) suffix = string.Empty;
                return input.Substring(startIndex, length) + suffix;
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
