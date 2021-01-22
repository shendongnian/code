    delegate int MyDelegate(int a, int b);
    public int Add(int a, int b) {
        return a + b;
    }
    public void InvokeMethod(Delegate method, object[] param) {
        Console.WriteLine(method.DynamicInvoke(param));
    }
    public Form1() {       
        InitializeComponent();
        InvokeMethod(new MyDelegate(Add), new object[] { 1, 2 });
    }
