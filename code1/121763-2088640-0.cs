    // A.cs:
    partial class Program {
        static int x = y + 42;
        static void Main() {
           System.Console.WriteLine("x: {0}; y: {1}", x, y);
        }
    }
    
    // B.cs:
    partial class Program {
        static int y = x + 42;
    }
