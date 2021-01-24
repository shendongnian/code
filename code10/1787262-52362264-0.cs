    public class Program {
        public static void Main(String[] args) {               
            Boolean debug = false;
            CheckForDebug(ref debug);
            Console.WriteLine("debug = " + debug);
        }
        [Conditional("DEBUG")]
        public static void CheckForDebug(ref Boolean debug)
        {
            debug = true;
        }
    }
