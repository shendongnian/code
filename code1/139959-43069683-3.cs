    using System;
    
    class Program {
        static void Main(string[] args) {
            try {
                Test();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
        static void Test() {
            try {
                throw new ArgumentException();  // Line 15
            }
            catch {
                throw;                          // Line 18
            }
        }
    }
