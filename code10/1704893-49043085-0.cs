    string ids = String.Join(",", dt.AsEnumerable().Select(x => x.Field<int>("ID").ToString()).ToArray());
    SQLCmd.Parameters.AddWithValue("@ID",ids);
    SQLCmd.CommandText = @"select ID from TestTable2 where ID in ("+@ID+")";
    SqlDataAdapter SQLAdapter = new SqlDataAdapter(SQLCmd);
    DataTable dt2 = new DataTable();
    SQLAdapter.Fill(dt2);
