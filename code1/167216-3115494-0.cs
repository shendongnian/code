    public delegate void MyDelegate(int myInt, string myString);
    public void FunctionToCall(int i, string s)
    {
        Console.WriteLine(s + " [" + i.ToString() + "]");
    }
    public void MethodWithFunctionPointer(MyDelegate callback)
    {
        callback(5, "The value is: ");
    }
