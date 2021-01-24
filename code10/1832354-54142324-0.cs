    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Test01
    {
        class Program
        {
            static void Main(string[] args)
            {
                int totalStock = 10;
    
                var fruits = new Dictionary<string, int>
                {
                    {"Apples", 3},
                    {"pears", 4}
                };
                var fruitsValuesCount = new List<int>(fruits.Values);
                var fruitsValuesSum = fruitsValuesCount.Sum();
                int totalFruits = totalStock - fruitsValuesSum;
                if (fruitsValuesSum > totalStock)
                {
                    Console.WriteLine("You have too many fruits! Please get rid of " + totalFruits + " fruits");
                }
                else if (fruitsValuesSum == totalStock)
                {
                    Console.WriteLine("You have just the right amount of fruits!");
                }
                else
                {
                    Console.WriteLine("You can fit " + totalFruits + " fruits");
                }
    
            }
        }
    }
