    public static class CExtensions
    {
        public static int SomeExtensionToC(this C someC, int someInt)
        {
           return someInt * 2;
        }
    }
    ... in code ...
    B objB = new B();
    y = objB.SomeExtensionToC(x);
