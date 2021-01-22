    public enum MyEnum
    {
        MyValue1 = 4,
        MyValue2 = 5,
        MyValue3 = 6
    }
    
    // Sample usage
    MyEnum firstEnum = MyEnum.MyValue1;
    int intVal = (int)firstEnum;    // results in 4
    
    // Enum Validation
    bool valid = Enum.IsDefined(typeof(MyEnum), intVal);   // results in true
