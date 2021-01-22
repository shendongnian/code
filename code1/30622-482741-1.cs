    string[] names = Enum.GetNames(typeof(MyEnum));
    MyEnum[] values = (MyEnum[])Enum.GetValues(typeof(MyEnum));
    
    for( int i = 0; i < names.Length; i++ )
    {
        print(names[i], values[i]);
    }
