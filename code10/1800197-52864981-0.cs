    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                IntStack mystack = new IntStack();
                mystack.Push(10);
                System.Console.WriteLine(mystack.Pop());
                mystack.Push(20);
                mystack.Push(30);
                mystack.Push(40);
                System.Console.WriteLine(mystack.Pop());
                System.Console.WriteLine(mystack.Pop());
                System.Console.WriteLine(mystack.Pop());
                System.Console.ReadKey();
            }
      
        }
        public class IntStack
        {
            private List<int> stack = new List<int>();
            
            public int? Pop()
            {
                if (stack.Count == 0) return null;
                int value = stack[0];
                stack.RemoveAt(0);
                return value;
            }
            public void Push(int value)
            {
                stack.Insert(0, value);
            }
        }
     
    }
