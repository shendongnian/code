    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Required arguments: <list of checked> <list of remaining>");
                return;
            }
            var checkedList = new List<string>(args[0].Split(','));
            var remainingList = new List<string>(args[1].Split(','));
            
            Console.WriteLine("Checked items:");
            foreach (var item in checkedList)
            {
                Console.WriteLine($"  {item}");
            }
            Console.WriteLine("Remaining items:");
            foreach (var item in remainingList)
            {
                Console.WriteLine($"  {item}");
            }
        }
    }
