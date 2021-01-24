    static void Main(string[] args)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Machine", typeof(string));
        table.Columns.Add("Code", typeof(SqlInt32));
        table.Columns.Add("Date_time", typeof(DateTime));
        DataRow dr = table.NewRow();
        dr.ItemArray = new object[] { "machineA", 1122, DateTime.Now };
        // Works
        Int32 i32 = ((SqlInt32)dr["Code"]).Value;
        // Throws 'Specified cast is not valid.'
        Int16 i16 = (short)dr["Code"];
    }
