    class X
    {
        protected internal /*virtual*/ void Method()
        {
            WriteLine("X");
        }
    }
    class Y : X
    {
        protected internal /*override*/ void Method()
        {
            base.Method();
            WriteLine("Y");
        }
    }
    class Z : Y
    {
        protected internal /*override*/ void Method()
        {
            base.Method();
            WriteLine("Z");
        }
    }
    class Programxyz
    {
        private static void Main(string[] args)
        {
            X v = new Z();
            //Y v = new Z();
            //Z v = new Z();
            v.Method();
    }
