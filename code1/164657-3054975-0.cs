    public static class EnumDictExt
    {
        public static TValue Lookup<TValue, TEnum>(this IDictionary<string, TValue> dict, TEnum e)
                where TEnum : struct, IComparable, IFormattable, IConvertible
            { return dict[e.ToString()]; }
    }
