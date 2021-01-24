    class Program
    {
        class Person                             //The class
        {
            public string jobTitle = "Cashier";    
            public void Greet()                    
            {
                Console.WriteLine("Hi, im bob.");
            }
        }
        public static void Main(string[] args)   //Method it was instantiated in
        { 
            // Bob is instantiated local to the main method
            Person Bob = new Person();
            Bob.Greet();
            //You didn't call OtherMethod() here
        }
        public static void OtherMethod()      //Method I want to access it in
        {
            // Since Bob was not passed in as a parameter or accessible via a global var, here you dont have access to it.  access it
            Bob.Greet();
            Console.WriteLine(Bob.jobTitle);  //"'Bob' does not exist in the current context"
        }
    }
