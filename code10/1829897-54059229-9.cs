    using System;
    namespace StackoverflowProblem
    {
        public interface ISeries
        {
            void Setstart(ref int value);
            int GetNext(ref int value);
            void Reset(ref int value);
        }
    
        public class Class1 : ISeries
        {
            public int val { get; set; }
    
            public void Setstart(ref int value)
            {
                this.val = value;
            }
    
            public int GetNext(ref int value)
            {
                value = value + 1;
                this.val = value;
    
                return this.val;
            }
    
            public void Reset(ref int value)
            {
                // Resetting val.
                value = 0;
                this.val = value;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Class1 c = new Class1();
    
                int value = 2;
                c.Setstart(ref value);
    
                Console.WriteLine(" " + c.GetNext(ref value));
    
                c.Reset(ref value);
                Console.WriteLine();
            }
        }
    }
