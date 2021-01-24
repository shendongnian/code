    [assembly: XmlnsDefinition("http://schemas.Demo", "MyNameSpace")]
        
    namespace MyNameSpace
    {
        public interface IMyInterface
        {
            string MyProperty { get; set; }
        }
    
        public class MyClass : IMyInterface
        {
            public string MyProperty { get; set; }
        }
    
        public static class MyClassFactory
        {
            public static IMyInterface Create()
            {
                return new MyClass();
            }
        }
    
        public class TestClass
        {
            public static void Test()
            {
                var myInterface = XamlServices.Parse(@"<IMyInterface xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" xmlns=""http://schemas.Demo"" 
        x:FactoryMethod=""MyClassFactory.Create"" 
        MyProperty=""MyValue""/>") as IMyInterface;
                Debug.Assert(myInterface != null);
            }
        }
    }
