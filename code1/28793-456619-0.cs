            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("id", typeof(int));
            ds.Tables[0].Columns.Add("firstname", typeof(string));
            ds.Tables[0].Columns.Add("lastname", typeof(string));
            ds.Tables[0].Rows.Add(1,"torvalds", "linus");
            ds.Tables[0].Rows.Add(2,"lennon", "john");
            
            ds.Tables[0].Columns.Add("name", typeof(string));
            foreach (DataRow dr in ds.Tables[0].Rows) dr["name"] = dr["lastname"] + ", " + dr["firstname"];
            foreach (DataRow dr in ds.Tables[0].Rows)
                MessageBox.Show(dr["name"]);
