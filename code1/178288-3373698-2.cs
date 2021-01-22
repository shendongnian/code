            string[] input = myOutput.ReadToEnd().Split('\n');
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("UserName", typeof(string)));
            table.Columns.Add(new DataColumn("SessionId", typeof(string)));
            foreach (string item in input)
            {
                DataRow row = table.NewRow();
                row[0] = item.Split(',')[0];
                row[1] = item.Split(',')[1];
                table.Rows.Add(row);
            }
            myGridView.DataSource = table;
            // for WebForms:
            myGridView.DataBind();
