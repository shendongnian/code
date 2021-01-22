        // this is a definition of a 3.5 class for use in 2.0.  If we upgrade to target CF3.5, we will need to remove it...
        namespace System.Runtime.CompilerServices 
        { 
            public class ExtensionAttribute : Attribute { } 
        }
    
    namespace TestExtension
    {
        public static class Extensions
        {
            public static int TestMethod(this string value)
            {
                return value.ToString();
            }
        }
    }
