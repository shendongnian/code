    public delegate void MyDelegate(int a);
    MyDelegate d = delegate { }; //valid
    MyDelegate d = delegate(int a) { }; //valid
    MyDelegate d = delegate(int a, int b) { }; //invalid
    public delegate void MyDelegateOut(int a, out int b);
    MyDelegateOut d = delegate { }; //invalid
