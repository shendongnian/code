    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Id", typeof(string)));
    dt.Columns.Add(new DataColumn("Name", typeof(string)));
    foreach (Entry entry in entries)
        dt.Rows.Add(new string[] { entry.Id, entry.Name });
    using (SqlBulkCopy bc = new SqlBulkCopy(connection))
    {   // the following 3 lines might not be neccessary
        bc.DestinationTableName = "Entries";
        bc.ColumnMappings.Add("Id", "Id");
        bc.ColumnMappings.Add("Name", "Name");
        bc.WriteToServer(dt);
    }
