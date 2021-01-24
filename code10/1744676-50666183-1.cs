    using System;
    using System.Collections.Generic;
    
    namespace Average
    {
        class Program
        {
            static void Main(string[] args)
            {
                Calculator calc = new Calculator();
                bool read = true;
                List<int> list = new List<int>();
                do
                {
                    string input = Console.ReadLine();
                    int x = 0;
                    if (input == "start")
                    {
                        read = false;
                    }
                    else if (int.TryParse(input, out x))
                    {
                        list.Add(x);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                } while (read);
                Console.WriteLine(calc.Average(list));
                Console.ReadKey();
            }
        }
        class Calculator
        {
            public double Average(List<int> list)
            {
                double value = 0;
                foreach(var z in list)
                {
                    value = value + z;
                }
                return value / (list.Count);
            }
        }
    }
