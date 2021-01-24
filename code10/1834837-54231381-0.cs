    static void Main(string[] args)
    {
      // Read all lines from file
      var lines = File.ReadAllLines("Path");
      string[] linesToWrite = new string[lines.Length];
      for (int i = 0; i < lines.Length; i++)
      {
        var cells = lines[i].Split('|');
        // Appned value in "TotalAcc" column at the end of current line
        // and store it in array of lines, that will be written to file
        linesToWrite[i] = lines[i] + cells[2];
      }
      File.WriteAllLines("path", linesToWrite);
    }
