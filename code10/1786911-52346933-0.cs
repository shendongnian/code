     private static IEnumerable<int[]> ReadData() {
       while (true) {
         Console.WriteLine("Next line of integers or q for quit");
         string input = Console.ReadLine().Trim();
         if (input == "q")
           break;
         yield return input
           .Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
           .Select(item => int.Parse(item)) // int.TryParse will be better
           .ToArray();
       }
     }
