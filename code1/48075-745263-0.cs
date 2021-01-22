    class TestClass {
      Action _myMethod;
      Action MyMethod {
        get { return _myMethod; }
        set { _myMethod = value; }
    }
    
    var tc = new TestClass()
    tc.MyMethod = () -> Console.WriteLine("Hello World!");
    tc.MyMethod()
