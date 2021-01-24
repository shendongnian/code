    public interface IType
    {
        string MyFunction();
    }
    public class MyType : IType
    {
        public string MyFunction() => "Abc";
    }
    class MyClass 
    {
        public MyClass(IType myType) 
        {
            Console.WriteLine(myType.MyFunction());
        }
    }
