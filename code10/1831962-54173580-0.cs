    static void Main(string[] args)
    {
        string input = "Twinkle twinkle little star";
        int length = 19;
        
        Console.WriteLine(CutOff(input,length));
    }
    
    private static string CutOff(string input, int length)
    {
        var solution = input.Substring(0, Math.Min(input.Length, Math.Max(0, length)));
        if (solution.ElementAt(solution.Length-1) == ' ')
            return solution.Trim();
    
        if (input.ElementAt(solution.Length)!=' ')
        {
            var temp = solution.Split(' ');
            var result = temp.Take(temp.Count() - 1).ToArray();  //remove the last word
            return string.Join(" ", result);  //convert array into a single string
        }
    
        return solution;
    }
