    private void OutputItem(string x)
    {
        Console.WriteLine(x);
        //maybe encapsulate additional logic to decide 
        // whether to also write the message to Trace or a log file
    }
    public IList<string> BuildListAndOutput(IEnumerable<string> x)
    {  // let's pretend IEnumerable<T>.ToList() doesn't exist for the moment
        IList<string> result = new List<string>();
  
        foreach(string y in x)
        {
            result.Add(y);
            OutputItem(y);
        }
        return result;
    }
