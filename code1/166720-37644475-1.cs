    SqlCeConnection conn = new SqlCeConnection("Data Source = Database1.sdf");
    SqlCeCommand query = conn.CreateCommand();
    query.CommandText = "myTableName";
    query.CommandType = CommandType.TableDirect;
    conn.Open();
    SqlCeDataReader myreader = query.ExecuteReader(CommandBehavior.KeyInfo);
    DataTable myDataTable= myreader.GetSchemaTable();
    //thats the code you asked. in the loop
    for (int i = 0; i < myDataTable.Rows.Count; i++)
    {
        listView1.Columns.Add(myDataTable.Rows[i][0].ToString());
    }
