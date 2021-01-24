    static void Main(string[] args)
    {
        int[] number = { 50, 40, 30, 30, 25, 25 };
    
        foreach (var kvp in Exercise(number, 100))
        {
            Console.WriteLine("Solution " + kvp.Key);
            foreach (var sol in kvp.Value)
            {
                Console.Write(sol + " ");
            }
            Console.WriteLine();
        }
    }
    
    private static Dictionary<int, List<int>> Exercise(int[] number, int sum)
    {
        Dictionary<int, List<int>> results = new Dictionary<int, List<int>>();
        int counter = 0;
    
        var numberOfCombinations = Math.Pow(2, number.Count());
        for (int i = 0; i < numberOfCombinations; i++)
        {
            //convert an int to binary and pad it with 0, so I will get an array which is the same size of the input[] array. ie for example 00000, then 00001, .... 11111 
            var temp = Convert.ToString(i, 2).PadLeft(number.Count(), '0').ToArray();
            List<int> positions = new List<int>();
            int total = 0;
            for (int k = 0; k < temp.Length; k++)
            {
                if (temp[k] == '1')
                {
                    total += number[k];
                    positions.Add(number[k]);
                }
            }
    
            if (total == sum)
            {
                results.Add(counter, positions);
                counter++;
            }
        }
    
        return results;
    }
