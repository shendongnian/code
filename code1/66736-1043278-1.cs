    static class MyStringUtilities
    {
        public static string IgnoreCaseReplace(this string text, string oldValue, string newValue)
        {
            int index = 0;
            while ((index = text.IndexOf(oldValue,
                index,
                StringComparison.InvariantCultureIgnoreCase)) >= 0)
            {
                text = text.Substring(0, index)
                    + newValue
                    + text.Substring(index + oldValue.Length);
    
                index += newValue.Length;
            }
    
            return text;
        }
    }
