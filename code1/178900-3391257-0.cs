    public delegate object myDelegate(object myParam);
    
    Public class MyClass
    {
        public static void Main()
        {
            myDelegate d = new myDelegate(myMethod);
            d.BeginInvoke ( new object() );
        }
    
        static void myMethod(object myParam)
        {
            // do some work!!
            return new object);
        }
    }
