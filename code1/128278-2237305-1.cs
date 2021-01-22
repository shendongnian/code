    static class DecimalExt {
        public static decimal PlusPlus(this decimal value) {
            decimal test = 1M;
            while (0 != value % test){
                test /= 10;
            }
            return value + test;
        }
    }
    class Program {
        public static void Main(params string[] args) {
            decimal x = 3.14M;
            x = x.PlusPlus(); // now is 3.15
        }
    }
