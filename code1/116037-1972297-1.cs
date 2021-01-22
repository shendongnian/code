    using System;
    
    struct MyValue
    {
        private readonly int value;
        public MyValue(int value) { this.value = value; }
        public static bool operator ==(MyValue x, MyValue y) {
            return x.value == y.value;
        }
        public static bool operator !=(MyValue x, MyValue y) {
            return x.value != y.value;
        }
    }
    class Program
    {
        static void Main()
        {
            int i = 1;
            MyValue v = new MyValue(1);
            if (i == null) { Console.WriteLine("a"); } // warning
            if (v == null) { Console.WriteLine("a"); } // no warning
        }
    }
