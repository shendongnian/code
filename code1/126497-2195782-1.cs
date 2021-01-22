    public static IDictionary<string, int> ToDictionary(this Enum enumeration)
    {
        int value = (int)(object)enumeration;
        return Enum.GetValues(enumeration.GetType()).OfType<int>().Where(v => (v & value) == value).ToDictionary(v => Enum.GetName(enumeration.GetType(), v));
    }
