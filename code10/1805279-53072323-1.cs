    class Program
    {
        MyClass myGlobalClass = new MyClass();
        static void Main(string[] args)
        {
            MyClass myLocalClass = new MyClass();
            //user the variable myLocalClass here
            //myGlobalClass will not work here because Main is static
        }
        private void NonStaticMethod()
        {
            //we can use myGlobalClass inside of this non-static method.
        }
    }
    public class MyClass
    {
        private void abc()
        { }
        public void xyz()
        { }
    }
