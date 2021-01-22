    public class MyClass
    {
        private static int MyInt;
        private static MyOtherClass MyOther;
        private static bool IsStaticInitialized = false;
    
        public static InitializeStatic(int myInt, MyOtherClass other)
        {
            MyInt = myInt;
            MyOther = other;
            IsStaticInitialized = true;
        }
       
        public MyClass()
        {
            if(!IsStaticInitialized)
            {
                throw new InvalidOperationException("Static Not Initialized");
            }
            // other constructor logic here. 
        }
    }
    
    // elsewhere in your code:
    MyClass.InitializeStatic(12, new MyOtherClass());
    MyClass myClass = new MyClass();
    // alternatiavely:
    MyClass myClass = new MyClass(); // runtime exception. 
