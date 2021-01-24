    static void Main() {
        Action test = Test;
        var name = test.GetName();
        name = ((Action<int>)Test2).GetName();            
    }
    public static void Test() {}
    public static void Test2(int arg) { }
