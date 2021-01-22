                comboBox.DisplayMember = "VALUE";
                comboBox.ValueMember = "ID";
    
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("VALUE");
    
                for (int i = 0; i < 5; i++)
                {
                    DataRow row = dt.NewRow();
                    row[0] = i;
                    row[1] = "val"+i;
                    dt.Rows.Add(row);
                }
                dt.AcceptChanges();
    
                comboBox.DataSource = dt;
