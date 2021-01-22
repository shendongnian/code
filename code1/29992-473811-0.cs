    private void Output(IEnumerable<string> x)
    {
        foreach (string y in x)
        {
            Console.WriteLine(y);
        }
    }
    public IList<string> BuildListAndOutput(IEnumerable<string> x)
    {
        IList<string> result = new List<string>();
  
        foreach(string y in x)
        {
            result.Add(y);
        }
        Output(result);
        return result;
    }
