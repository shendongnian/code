c#
    public enum Color
    {
        Red,
        Green,
        Blue
    }
    public static class EnumExtensions
    {
        public static IEnumerable<string> ToCombo<T>(this T type)
        {
            if (type.GetType().IsEnum)
            {
                return Enum.GetValues(type.GetType()).OfType<string>();
            }
            return Array.Empty<string>();
        }
    }
