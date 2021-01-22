    class Program {
        [STAThread]
        static void Main(String[] args) {
            Console.WriteLine("Have {0} arguments", args.Length);
            for (int i = 0; i < args.Length; ++i) {
                Console.WriteLine("{0}: {1}", i, args[i]);
            }
        }
    }
