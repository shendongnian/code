    List<string[]> separatedLines = new List<string[]>();
    
    lines.ForEach(x => separatedLines.Add(x.Split(' ')));
    if(separatedLines.AsQueryable().Any(s => s.Length != int.Parse(header[0])))
      throw new InvalidDataException("yadda, yadda");
