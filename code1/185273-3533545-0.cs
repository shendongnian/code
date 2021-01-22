    using(StreamReader sr = new StreamReader(fileName)
    {
      string header[] = sr.ReadLine().Split(' ');
      if(header.Length != 2) throw new InvalidDataException("yadda, yadda");
      List<string> lines = new List<string>(); 
      //you'll probably want to move that declaration outside the using statement...
      while(sr.Peek() != -1)
      {
        lines.Add(sr.ReadLine());
      }
      if(lines.Count() != int.Parse(header[1])) //this is wrong so...
        throw new InvalidDataException("yadda, yadda");
      if(lines.AsQueryable().Any(x => x.length != int.Parse(header[0]))// this, too
        throw new InvalidDataException("yadda, yadda");
    }
