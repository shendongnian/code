    var dt = new DataTable();
    dt.Columns.Add("AUDIT_PK", typeof (long));
    dt.Columns.Add("MESSAGE", typeof (string));
    dt.Columns.Add("SUCCESS", typeof (bool));
    dt.Rows.Add(1, "EHLO", null);
 
    using (var conn = new SqlConnection("Data Source=.;Initial  Catalog=Scratch;Integrated Security=true"))
    {
        conn.Open();
        conn.Execute("TestOne", new {TVP =   dt.AsTableValuedParameter("dbo.AUDITRECORD")}, commandType: CommandType.StoredProcedure);
    }
