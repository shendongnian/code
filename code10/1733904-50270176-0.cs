    static void Main()
    {
  
        Console.WriteLine("Investigation 1");
        Console.WriteLine("===============");
        Console.WriteLine();
        Console.Write("How many sets of tests? 1 to 10: ");
        int sets = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Random r = new Random();
        int[] counts = new int[13];
        for (int ctr = 0; ctr < 36 * sets; ctr++)
        {
            int a = r.Next(1, 7), b = r.Next(1, 7), total = a + b;
            Console.WriteLine($"Roll {(ctr + 1)}: {a} + {b} = {total}");
            counts[total]++;
        }
        Console.WriteLine("=======================");
        Console.WriteLine();
        Console.WriteLine("Total  Expected  Actual");
        Console.WriteLine("=====  ========  ======");
        for(int i = 2; i <= 12; i++)
        {
            var expected = sets * (6 - Math.Abs(7 - i));
            Console.WriteLine($"  {i}        {expected}        {counts[i]}");
        }
    }
