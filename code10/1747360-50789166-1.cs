    public class GUIModule
    {
        public bool Initializer()
        {
            Console.WriteLine("Initialized!");
            return true;
        }
    
        public bool Deinitializer()
        {
            Console.WriteLine("Deinitialized");
            return true;
        }
    }
