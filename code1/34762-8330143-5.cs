    private static void Display<T>(List<List<T>> generatedCombinations)
    {
        int index = 0;
        foreach (var generatedCombination in generatedCombinations)
        {
            Console.Write("{0}\t:", ++index);
            foreach (var i in generatedCombination)
            {
                Console.Write("{0,3}", i);
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }
 
