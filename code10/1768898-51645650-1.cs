    public static List<BookInfo> LoadCSVFile(string fileName, out string qError)
    {
       try
       {
    
          // read all lines in to another type
          // just makes it easier for errors which you seem to want
          var lines = File.ReadAllLines(fileName)
                          .Select(x => new { Values = x.Split(','), Text = x })
                          .ToList();
    
          // get a list of errors, 
          var errors = lines.Where(x => x.Values.Length != 3)
                            .Select((s, i) => $"Bad book! Line {i} : {s.Text}");
    
          // return some errors
          qError = string.Join(Environment.NewLine, errors);
    
          // project lines to your books    
          return lines.Where(x => x.Values.Length == 3)
                      .Select(x => new BookInfo(x.Values[0], x.Values[0], x.Values[0]))
                      .ToList();
       }
       catch (Exception e)
       {
          qError = e.Message;
       }
    
       return null;
    }
