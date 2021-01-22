    public IList<string> ReadFile(string path)
    {
        List<string> text = new List<string>();
        using(StreamReader reader = new StreamReader(path))
        {
          while (!reader.EndOfStream)      
          {         
             text.Add(reader.ReadLine());      
          }
        }
        return text;
    }
