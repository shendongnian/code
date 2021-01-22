    public static void Main()
    {
        Int64 time1 = With.Benchmark(MyLongMethod);
        Int64 time2 = With.Benchmark(delegate { MyLongMethod(1, true); });
    }
    private static void MyLongMethod() { }
    private static void MyLongMethod(Int32 index, Boolean someSwitch) { }
