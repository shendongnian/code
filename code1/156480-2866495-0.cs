    DataTable dt2 = new DataTable(); 
    DataRow dr2 = null; 
    dt2.Columns.Add("key"); 
    dt2.Columns.Add("value");
     dr2 = dt2.NewRow(); 
    dr2["key"] = comboA.SelectedItem.ToString(); 
    dr2["value"] = comboB.SelectedItem.ToString(); 
    dt2.Rows.Add(dr2); 
    this.dataGridView1.DataSource = dt2
