    public IList<string> BuildListAndOutput(IEnumerable<string> x)
    {
        IList<string> result = new List<string>();
  
        foreach(string y in x)
        {
            result.Add(y);
            // full OutputItem() implementation is placed here
            Console.WriteLine(y);   
        }
        
        return result;
    }
