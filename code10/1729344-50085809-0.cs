    public class Singleton {
        static readonly float FLOAT_VAL = 3.5f;
        static readonly int INT_VAL = 3;
        public static readonly Singleton instance = new Singleton();
        private Singleton() {
            Console.WriteLine("FLOAT_VAL = " + FLOAT_VAL);
            Console.WriteLine("INT_VAL = " + INT_VAL);
        }
    }
