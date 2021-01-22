        var dt = new DataTable("Users");
        dt.Columns.Add(new DataColumn("Id", typeof(int)));
        dt.Columns.Add(new DataColumn("Password", typeof(byte[])));
        dt.Columns.Add(new DataColumn("Username"));
        dt.Columns.Add(new DataColumn("Email"));
        dt.Columns.Add(new DataColumn("CreatedAt", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Bio"));
        
        for (int i = 0; i < count; i++)
        {
        	var row = dt.NewRow();
        	row["Id"] = i;
        	row["Password"] = Guid.NewGuid().ToByteArray();
        	row["Username"] ="User " + i;
        	row["Email"] = i + "@example.org";
        	row["CreatedAt"] =DateTime.Now;
        	row["Bio"] =  new string('*', 128);
        	dt.Rows.Add(row);
        }
        
    using (var connection =
     ((ISessionFactoryImplementor)sessionFactory).ConnectionProvider.GetConnection())
    {
    	var s = (SqlConnection)connection;
    	var copy = new SqlBulkCopy(s);
    	copy.BulkCopyTimeout = 10000;
    	copy.DestinationTableName = "Users";
    	foreach (DataColumn column in dt.Columns)
    	{
    		copy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
    	}
    	copy.WriteToServer(dt);
    }
