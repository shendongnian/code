    string result = 
      ingredients                    // List<string>
      .Permute()                     // IEnumerable<IEnumerable<string>>
      .Select(p => p.StringSort())   // IEnumerable<IEnumerable<string>>
      .Select(p => p.CommaSeparate())// IEnumerable<string>
      .NewLines();                   // string
