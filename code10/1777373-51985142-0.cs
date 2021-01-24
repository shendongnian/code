        DataGridViewComboBoxCell dgvcell;
        for (int x = 0; (x <= (DataGridView1.Rows.Count - 1)); x++) 
        {
        SQL_cmd.CommandText = "select something from somethingelse where something = @something ";
            sql_cmd.parameters.addwithvalue("@something", DataGridView1.Rows[x].Cells["something"].Value);
            SQL_reader = SQL_cmd.ExecuteReader;
            while (SQL_reader.Read) {
            dgvcell = ((DataGridViewComboBoxCell)(this.DataGridView1.Rows(x).Cells["something"]));
            dgvcell.Items.Add(SQL_reader("something"));
            }
                        
            SQL_reader.Close();
        }
