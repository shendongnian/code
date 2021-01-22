    var inputCommands = args
        .Select((value, idx) => new { Value = value, Group = idx / 2 })
        .GroupBy(x => x.Group) 
        .Select(g => new  
        {  
          Command = g.First().Value,  
          Argument = g.Last().Value  
        }).ToList();
    
    inputCommands.ForEach(x => 
    {
      Action<string> theAction = 
      (
        from kvp in commands
        where kvp.Key.Contains(x.Command)
        select kvp.Value
      ).FirstOrDefault();
      if (theAction != null)
      {
        theAction(x.Argument);
      }
    }
