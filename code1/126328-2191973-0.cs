    using System;
    class Program {
        public static void Main() {
            try {
                throw new Exception("test");
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
