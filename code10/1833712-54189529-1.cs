    public static RemoveClient(string firstName, string lastName)
    {
      StringBuilder builder = new StringBuilder();
      foreach(var line in File.ReadAllLines(@"C:\Users\Adminl\Documents\clients.txt")
      {
        var split = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
        if(split.Count < 3 || split[1] != firstName || split[2] != lastName) //|| any other comparisons you'd like to do
          builder.AppendLine(line);
      }
    
      using(var writer = new StreamWriter(@"C:\Users\Adminl\Documents\clients.txt"))
      {
        writer.Write(builder.ToString());
        writer.Flush();
      }
    }
