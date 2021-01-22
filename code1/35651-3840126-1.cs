    public static class MyExtensions
    {
        public static string MyExtension<T>(this T obj)
        {
            return "Hello World!";
        }
    }
    public interface IExtensionMethodsWrapper
    {
        string MyExtension<T>(T myObj);
    }
    public class ExtensionMethodsWrapper : IExtensionMethodsWrapper
    {
        public string MyExtension<T>(T myObj)
        {
            return myObj.MyExtension();
        }
    }
