     DataSet ds = new DataSet();
                 
                DataTable dt = new DataTable("MyTable");
                dt.Columns.Add(new DataColumn("id",typeof(int)));
                dt.Columns.Add(new DataColumn("name", typeof(string)));
    
                DataRow dr = dt.NewRow();
                dr["id"] = 123;
                dr["name"] = "John";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
