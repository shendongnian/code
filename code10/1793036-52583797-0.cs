    using System;
    
    namespace threemethods
    {
    
        public class Operator
        {
            public double GetAdd(int data)
            {
                data = data + 4;
                return GetSubtract(data);
            }
    
            private double GetSubtract(double data)
            {
                data = data - 3;
                return GetDivide(data);
            }
    
            private double GetDivide(double data)
            {
                return data / 3;
            }
        }
        class Program
        {
            public static int Data { get; set; }
            static void Main(string[] args)
            {
                Console.WriteLine("Enter input:");
                string line = Console.ReadLine();
                Data = Int32.Parse(line);
                var operatorObject = new Operator();
                var result = operatorObject.GetAdd(Data);
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
