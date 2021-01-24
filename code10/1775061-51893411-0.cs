    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CUrsorPosition
    {
        class Program
        {
           static int lastCursorLocation = 0;
           //customCursorPosition say which line number you want the cursor to //set after the last text for example i have set it to 1 so next line to hellow //world
           static int customCursorPosition = 1;
            static void Main(string[] args)
            {
                // int customCursorPosition = 0;
                WriteLine(".");
                WriteLine(".");
                WriteLine(".");
                WriteLine(".");
                
                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                Console.CursorTop = Console.WindowTop + Console.WindowHeight - 1;
                Console.SetCursorPosition(x, y);
                WriteLine("Hello World");
                Console.SetCursorPosition(0, y+ customCursorPosition);
                Console.ReadLine();
    
    
            }
            static void WriteLine(string message, [CallerLineNumber] int lineNumber = 0)
            {
                Console.WriteLine(lineNumber + ": " + message);
            }
            static void WriteLine(string message)
            {
                StackFrame callStack = new StackFrame(1, true);
                var lineNumber = callStack.GetFileLineNumber();
                lastCursorLocation = callStack.GetFileLineNumber();
                Console.WriteLine(message);
                
            }
        }
    }
