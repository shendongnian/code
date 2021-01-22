    public static class YourHelper
    {
        public static void AddCharRange(this List<char> list, char first, char last)
        {
            for (char c = first; c <= last; c++)
            {
                list.Add(c);
            }
        }
    }
