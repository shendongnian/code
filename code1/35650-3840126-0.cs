    public static class MyExtensions
    {
        public static string MyExtension<T>(this T obj)
        {
            return "Hello World!";
        }
    }
    public interface IExtensionMethodsWrapper
    {
        string MyExtension<T>(t myObj);
    }
    public class ExtensionMethodsWrapper
    {
        public string MyExtension<T>(t myObj)
        {
            return myObj.MyExtension();
        }
    }
