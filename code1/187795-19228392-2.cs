    System.Type enumType = typeof(TestEnum);
    System.Type enumUnderlyingType = System.Enum.GetUnderlyingType(enumType);
    System.Array enumValues = System.Enum.GetValues(enumType);
    for (int i=0; i < enumValues.Length; i++)
    {
        // Retrieve the value of the ith enum item.
        object value = enumValues.GetValue(i);
        // Convert the value to its underlying type (int, byte, long, ...)
        object underlyingValue = System.Convert.ChangeType(value, enumUnderlyingType);
        System.Console.WriteLine(underlyingValue);
    }
