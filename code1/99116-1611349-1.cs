    using System;    
    class Program {
        static void Main() {
            Write();
            Write(msg: "world");
            Console.ReadLine();
        }
        static void Write(string msg = "Hello") {
            Console.WriteLine(msg);
        }
    }
