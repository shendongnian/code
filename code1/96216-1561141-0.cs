    DataTable dt = new DataTable();
                dt.Columns.Add("Col");
                dt.Rows.Add();
                dt.Rows.Add();
                dt.Rows.Add();
                dt.Rows[0][0] = "1";
                dt.Rows[1][0] = "2";
                dt.Rows[2][0] = "3";
                dataGridView1.DataSource = dt;
    
                dataGridView1.Columns.Add(new DataGridViewComboBoxColumn());
    
                List<string> lstStr = new List<string>();
                lstStr.Add("1");
                lstStr.Add("2");
                lstStr.Add("3");
                lstStr.Add("4");
    
                ((DataGridViewComboBoxCell)(dataGridView1.Rows[0].Cells[1])).DataSource = lstStr;
