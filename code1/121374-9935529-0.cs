    class CSVHelper : List<string[]>
    {
      protected string csv = string.Empty;
      protected string seperator = ",";
      public CSVHelper(string csv, string separator = ",")
      {
        this.csv = csv;
        this.separator = separator;
        foreach(string line in Regex.Split(csv, System.Environment.NewLine))
        {
           string[] values = Regex.Split(csv, separator);
           for(int i = 0; i < values.Length; i++)
           {
              //Trim values
              values[i] = values[i].Trim('\"');
           }
           this.Add(values);
        }
      }
    }
