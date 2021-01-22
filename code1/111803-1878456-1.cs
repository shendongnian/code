    public interface IShareFunctionality { }
    
    public static class Extensions
    {
        public static bool DoSomething(this IShareFunctionality input)
        {
            return input == null;
        }
    }
    
    public class MyClass : Object, IShareFunctionality
    {
        public void SomeMethod()
        {
            if(this.DoSomething())
                throw new Exception("Impossible!");
        }
    }
