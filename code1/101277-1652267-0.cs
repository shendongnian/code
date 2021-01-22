    public interface IMyInterface
    {
        bool GetMyInfo(string request);
    }
    
    public class MyClass : IMyInterface
    {
        public void SomePublicMethod() { }
    
        bool IMyInterface.GetMyInfo(string request)
        {
            // implementation goes here
        }
    }
