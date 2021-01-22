    public class chimp
        {
            public virtual void walk()
            {
                Console.WriteLine("I am walking using 4 legs");
            }
    
        }
    
        public class neanderthals : chimp
        {
            public override void walk()
            {
                Console.WriteLine("I am walking using 2 legs");
            }
    
        }
    
    
    
        class Program
        {
            static void Main(string[] args)
            {
                chimp x = new neanderthals();
                x.walk();
                Console.ReadLine(); // this will give an output of "I am walking using 2 legs"
            }
        }
