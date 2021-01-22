    namespace MyLib
    {
        public class MyClass
        {
            static MyClass()
            {
                ResourceExtractor.ExtractResourceToFile("MyLib.ManagedService.dll", "managedservice.dll");
                ResourceExtractor.ExtractResourceToFile("MyLib.UnmanagedService.dll", "unmanagedservice.dll");
            }
    
            ...
