    public class Person                            
    {
        public string jobTitle = "Cashier";    
        public void Greet()                
        {
            Console.WriteLine("Hi, im bob.");
        }
    }
    public static class Program
    {
        private Person _bob;
        public static void Main(string[] args)   
        {
            _bob = new Person();
            _bob.Greet();
            OtherMethod();
    
        }
    
        public static void OtherMethod()      
        {
            _bob.Greet();
            Console.WriteLine(_bob.jobTitle);  
        }
    }
