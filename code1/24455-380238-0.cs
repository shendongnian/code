    static object InvokeMethod(Delegate method, params object[] args){
        return method.DynamicInvoke(args);
    }
    static int Add(int a, int b){
        return a + b;
    }
    static void Test(){
        Console.WriteLine(InvokeMethod(new Func<int, int, int>(Add), 5, 4));
    }
