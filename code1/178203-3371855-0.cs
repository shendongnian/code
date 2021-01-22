    public class AnotherClass
    {
        public int InstanceVariable = 42;
    }
    
    public class Program
    {
        static AnotherClass x = new AnotherClass(); // This is static.
        
        static void Main(string[] args)
        {
            Console.WriteLine(x.InstanceVariable);
        }
    }
