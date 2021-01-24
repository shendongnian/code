    using System;
    
    namespace StackoverflowProblem
    {
        public interface ISeries
        {
            void Setstart(ref int value);
            int GetNext(ref int value);
            void Reset(ref int value);
        }
    
        public class Series : ISeries
        {
            public int val { get; set; }
    
            public void Setstart(ref int value)
            {
                this.val = value;
            }
    
            public int GetNext(ref int value)
            {
                this.val = value++;
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
                Series series = new Series();
    
                int value = 10;
                series.Setstart(ref value);
                var value_Recieved = series.GetNext(ref value);
    
                //...
                Console.WriteLine(value);
    
                series.Reset(ref value);
    
                //...
                Console.WriteLine(value);
            }
        }
    }
