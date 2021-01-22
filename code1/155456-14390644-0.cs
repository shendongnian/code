             DataTable dt = new DataTable();
            dt.Columns.Add("ID",typeof(int));
            dt.Columns.Add("Produto Nome", typeof(string));  
            
            dt.Rows.Add(null, "A");
            dt.Rows.Add(null, "B");
            dt.Rows.Add(null, "C");
            for(int i=0;i < dt.Rows.Count;i++)
            {
                dt.Rows[i]["ID"] = i + 1;
            }
