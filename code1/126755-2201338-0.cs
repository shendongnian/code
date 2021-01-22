    public dynamic ParseCsvFile(string filePath) {
      var expando = new ExpandoObject;
      IDictionary<string,object> map = expando;
      foreach ( var line in File.ReadAllLines(filePath)) {
        var array = line.Split(new char[]{','},2);
        map.Add(array[0],array[1]);
      }
      return expando;
    }
    
    ...
    var d = ParseCsvFile(someFilePath);
    Console.WriteLine(d.Property1);
