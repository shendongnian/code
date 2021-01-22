    using System;
    
    namespace ExtensionMethodTest.Domain
    {
        public static class MyClassExtensions
        {
            public static string UpperCaseName (this MyClass myClass)
            {
                return myClass.Name.ToUpper();
            }
        }
    }
