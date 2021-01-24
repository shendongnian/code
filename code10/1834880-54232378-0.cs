    public enum CountryListEnum
    {
        [Description("United Kingdom")]
        UnitedKingdom = 0,
        [Description("United States")]
        UnitedStates = 1,
        [Description("Afghanistan")]
        Afghanistan = 2,
        [Description("Albania")]
        Albania = 3,
    }
    static void Main(string[] args)
    {
        foreach (var country in Enum.GetValues(typeof(CountryListEnum)).Cast<CountryListEnum>())
        {
            Console.WriteLine($"Index: {(int)country}");
            Console.WriteLine($"Description: {GetDescription(country)}");
        }
    }
    public static string GetDescription(Enum value)
    {
        Type type = value.GetType();
        string name = Enum.GetName(type, value);
        if (name != null)
        {
            System.Reflection.FieldInfo field = type.GetField(name);
            if (field != null)
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                {
                    return attr.Description;
                }
            }
        }
        return null;
    }
