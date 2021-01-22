    // you need this once (only), and it must be in this namespace
    namespace System.Runtime.CompilerServices
    {
        [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class
             | AttributeTargets.Method)]
        public sealed class ExtensionAttribute : Attribute {}
    }
    // you can have as many of these as you like, in any namespaces
    public static class MyExtensionMethods {
        public static int MeasureDisplayStringWidth (
                this Graphics graphics, string text )
        {
               /* ... */
        }
    }
