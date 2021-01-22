    static void Main(string[] args)
    {
      var x = ExportFormat.Csv | ExportFormat.Excel;
      var y = (ExportFormat)350;
      var xx = x.IsDefined();  //true
      var yy = y.IsDefined();  //false
    }
    public static bool IsDefined(this Enum value)
    {
      if (value == null) return false;
      foreach (Enum item in Enum.GetValues(value.GetType()))
        if (item.HasFlag(value)) return true;
      return false;
    }
