    public enum TestEnum
    {
        MyFirstEnum,
        MySecondEnum
    }
    static void TestEnums()
    {
        string str = TestEnum.MyFirstEnum.ToString();
        Console.WriteLine( "Enum = {0}", str );
        TestEnum e = (TestEnum)Enum.Parse( typeof( TestEnum ), "MySecondEnum", true );
        Console.WriteLine( "Enum = {0}", e );
    }
