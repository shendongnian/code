    static void Main(string[] args)
    {
      var x = ExportFormat.Csv | ExportFormat.Excel;
      var y = ExportFormat.Csv | ExportFormat.Word;
      var z = (ExportFormat)16; //undefined value
          
      var xx = x.IsDefined();  //true
      var yy = y.IsDefined();  //false
      var zz = z.IsDefined();  //false
    }
    public static bool IsDefined(this Enum value)
    {
      if (value == null) return false;
      foreach (Enum item in Enum.GetValues(value.GetType()))
        if (item.HasFlag(value)) return true;
      return false;
    }
    [Flags]
    public enum ExportFormat                                      
    {
      None = 0,
      Csv = 1,
      Tsv = 2,
      Excel = 4,
      Word = 8,
      All = Excel | Csv | Tsv
    }
