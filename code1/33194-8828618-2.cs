    static void Main(string[] args)
    {
      var x = ExportFormat.Csv | ExportFormat.Excel;
      var y = ExportFormat.Csv | ExportFormat.Word;
      var z = (ExportFormat)350;
            
      var xx = x.IsDefined();  //true
      var yy = y.IsDefined();  //true
      var zz = z.IsDefined();  //false
    }
    public static bool IsDefined(this ExportFormat value)
    {
      var max = Enum.GetValues(typeof(ExportFormat)).Cast<ExportFormat>()
        .Aggregate((e1,e2) =>  e1 | e2);
      return (max & value) == value;
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
