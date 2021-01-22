    System.Array enumValues = System.Enum.GetValues(typeof(MyEnum));
    for (int i=0; i < enumValues.Length; i++)
    {
        int intValue = (int)enumValues.GetValue(i);
        System.Console.WriteLine(intValue);
    }
