    public static void run()
    {
        var inputs =
            new List<Input>{
              new Input{ 
                  Value = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },`
                  TargetCount = 5, ExpectedOutput= new List<int>{1,3,5,7,9} 
              },
              new Input{  
                  Value = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                  TargetCount = 3, ExpectedOutput= new List<int>{1,4,7} 
              },
            };
        foreach (var testInput in inputs)
        {
            Console.WriteLine($"# Input = [{string.Join(", ", testInput.Value)}]");
            var result = Reduce(testInput.Value, testInput.TargetCount);
            Console.WriteLine($"# Computed Result = [{string.Join(", ", result)} ]\n");
        }
    }
    static List<int> Reduce(List<int> input, int targetItemsCount)
    {
        while (input.Count() > targetItemsCount)
        {
            var nIndex = input.Count() / targetItemsCount;
            input = input.Where((x, i) => i % nIndex == 0).ToList();
        }
        return input;
    }
    class Input
    {
        public List<int> ExpectedOutput;
        public List<int> Value;
        public int TargetCount;
    }
