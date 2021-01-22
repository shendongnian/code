    public static void Main()
    {
        Wrapper(new Action(TempMethod1));
    }
    private static void TempMethod1()
    {
        TestClass.Hello();
    }
