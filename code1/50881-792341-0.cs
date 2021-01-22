    public static IEnumerable<string> ReadLinesEnumerable(string path) {
      using ( var reader = new StreamReader(path) ) {
        var line = reader.ReadLine();
        while ( line != null ) {
          yield return line;
          line = reader.ReadLine();
        }
      }
    }
