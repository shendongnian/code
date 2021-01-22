    static class DecimalExt {
        public static decimal PlusPlus(this decimal value) {
            if (0 == value % 1) {
                return ++value;
            }
            decimal test = 0.1M;
            while (0 != value % test){
                test /= 10;
            }
            return value + test;
        }
    }
    class Program {
        public static void Main(params string[] args) {
            decimal x = 3.14M;
            x = x.PlusPlus();
        }
    }
