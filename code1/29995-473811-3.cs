    public IList<string> BuildListAndOutput(IEnumerable<string> x)
    {
        IList<string> result = new List<string>();
  
        foreach(string y in x)
        {
            result.Add(y);
            Console.WriteLine(y);  // would contain the full OutputItem() implementation here
        }
        
        return result;
    }
