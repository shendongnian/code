    public static class Extensions
    {
        public static bool IsCurrencySymbol(this char c)
        {
            return char.GetUnicodeCategory(c) == UnicodeCategory.CurrencySymbol;
        }
    }
