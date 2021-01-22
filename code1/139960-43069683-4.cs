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
                throw new ArgumentException();              // Line 15
            }
            catch(Exception ex) {
                ExceptionDispatchInfo.Capture(ex).Throw();  // Line 18
            }
        }
    }
