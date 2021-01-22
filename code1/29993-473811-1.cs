    public IList<string> BuildListAndOutput(IEnumerable<string> x)
    {
        IList<string> result = new List<string>();
  
        foreach(string y in x)
        {
            result.Add(y);
        }
        
        foreach (string z in result)
        {
            Console.WriteLine(z);
        }
        return result;
    }
