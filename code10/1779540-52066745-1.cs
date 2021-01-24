    public static class EnumHelpers
    {
        public static IEnumerable<TEnum> Sequence<TEnum>() where TEnum: struct, Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }
