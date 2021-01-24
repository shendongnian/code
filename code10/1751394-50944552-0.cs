    using (var sr = new StreamReader(fileName))
       while (!sr.EndOfStream)
       {
          var diety = new Deity();
          diety.Name = sr.ReadLine();
          diety.Origin = sr.ReadLine().Replace("Origin: ", string.Empty);
    
          string val;
          while (!string.IsNullOrWhiteSpace(val = sr.ReadLine()))
             diety.Description += val;
    
          deities.Add(diety);
       }
    
