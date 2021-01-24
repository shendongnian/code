    public static List<List<Result>> Permutate(IEnumerable<Input> inputs)
    {
        List<List<Result>> results = new List<List<Result>>();
        var size = inputs.Select(inp => factorial_WhileLoop(inp.Ids.Count)).Aggregate((item, carry) => item + carry) - 1;
        for (int i = 0; i < size; i++) results.Add(new List<Result>());
        foreach (var input in inputs)
        {
            for (int j = 0; j < input.Ids.Count; j++)
            {
                for (int i = 0; i < (size / input.Ids.Count); i++)
                {
                    var x = new Result() { Label = input.Label, Id = input.Ids[j] };
                    results[(input.Ids.Count * i) + j].Add(x);
                }
            }
        }
        return results;
    }
    public static int factorial_WhileLoop(int number)
    {
        var result = 1;
        while (number != 1)
        {
            result = result * number;
            number = number - 1;
        }
        return result;
    }
        
