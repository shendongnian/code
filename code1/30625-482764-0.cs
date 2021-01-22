    Dictionary<string, int> list = new Dictionary<string, int>();
    foreach( var item in Enum.GetNames(typeof(MyEnum)) )
    {
        list.Add(item, (int)Enum.Parse(typeof(MyEnum), item));
    }
