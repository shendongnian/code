    [assembly: XmlnsDefinition("http://schemas.Demo", "MyNameSpace")]
    
    namespace MyNameSpace
    {
        public interface IMyInterface
        {
            string MyProperty { get; set; }
        }
    
        public class MyClass : IMyInterface
        {
            public static IMyInterface Create()
            {
                return new MyClass();
            }
    
            public string MyProperty { get; set; }
    
            public static void Test()
            {
                var myInterface = XamlServices.Parse(
    @"<MyClass 
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" 
        xmlns=""http://schemas.Demo"" 
        x:FactoryMethod=""MyClass.Create"" 
        MyProperty=""MyValue""/>") as IMyInterface;
            }
        }
    }
