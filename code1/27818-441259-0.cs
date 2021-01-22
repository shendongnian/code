    class Program
    {
        public MyCustomClass myClass;
        public Program()
        {
            // Create an object of type MyCustomClass.
            myClass = new MyCustomClass();
    
            // Set the value of a public property.
            myClass.Number = 27;
    
            // Call a public method.
            int result = myClass.Multiply(4);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
        }
    }
