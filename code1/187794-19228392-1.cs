    System.Array enumValues = System.Enum.GetValues(typeof(MyEnum));
    for (int i=0; i < enumValues.Length; i++)
    {
        object value = enumValues.GetValue(i);
        object underlyingValue = Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()));
        System.Console.WriteLine(underlyingValue);
    }
