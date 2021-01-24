    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace EntryPoint.Concole
    {
        class Program
        {
            static void Main(string[] args)
            {
               List<int> numberList = new List<int>();
               List<int> uniqueList = new List<int>();
               string input;
               int number = 0;
               bool over = false;
               while (!over)
               {
                   input = Console.ReadLine();
                   if (input == "quit")
                   {
                      over = true;
                      break;
                   }
                   if (int.TryParse(input, out number))
                   {
                      numberList.Add(number);
                   }
               }
               var numbersDistinct = numberList.GroupBy(i => i);
               foreach (var num in numbersDistinct)
               {
                  if (num.Count() == 1)
                  {
                      uniqueList.Add(num.Key);
                  }
               }
               for (int i = 0; i < uniqueList.Count; i++)
               {
                  Console.WriteLine(uniqueList[i]);
               }
               Console.ReadKey();
            }
        }
  
