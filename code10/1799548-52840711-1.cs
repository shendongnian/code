    public class MyTestingType : IType
    {
        public string MyFunction() => "Def";
    }
    class Unittests 
    {
        public void Test() 
        {
            new MyClass(new MyTestingType());
        }
    }
