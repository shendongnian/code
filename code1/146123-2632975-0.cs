    delegate void FunctionA();
    delegate FunctionA FunctionB();
    void TestA() { }
    FunctionA TestB() { return TestA; }
    void Main()
    {
       TestB()();
    }
