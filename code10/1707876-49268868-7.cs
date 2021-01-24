    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Atlanta", typeof(string));
      dt.Columns.Add("Boston", typeof(string));
      dt.Columns.Add("Brooklyn", typeof(string));
      return dt;
    }
