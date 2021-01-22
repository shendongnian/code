    public class MyClass : BaseClass
    {
        private MyClass(string someString) : base(someString)
        {
            //your code goes in here
        }
        public static MyClass FactoryMethod(string someString)
        {
            //whatever you want to do with your string before passing it in
            return new MyClass(someString);
        }
    }
