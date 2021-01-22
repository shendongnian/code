    public static class EnumExtensions
    {
        public static string ToFriendlyString(this Enum code)
        {
            return Enum.GetName(code.GetType(), code);
        }
    }
