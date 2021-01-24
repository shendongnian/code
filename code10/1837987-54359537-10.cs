    private DataTable GetSplitTable(DataTable sourceTable) {
      DataTable dt = new DataTable();
      dt.Columns.Add("AgeRange", typeof(string));
      dt.Columns.Add("StartRange", typeof(int));
      dt.Columns.Add("EndRange", typeof(int));
      foreach (DataRow row in sourceTable.Rows) {
        int startValue = GetIntValue(row.ItemArray[0].ToString(), 0);
        int endValue = GetIntValue(row.ItemArray[0].ToString(), 1);
        dt.Rows.Add(row.ItemArray[0], startValue, endValue);
      }
      return dt;
    }
    private int GetIntValue(string rangeString, int index) {
      string[] splitArray = rangeString.Split('-');
      int value = 0;
      int.TryParse(splitArray[index], out value);
      return value;
    }
