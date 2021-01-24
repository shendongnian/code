    Form5 re = new Form5();
    int result = 0;
    DataTable dt = new DataTable();
    dt.Columns.Add("Result");
    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
    {
        DataRow row = dt.NewRow();
        var src1 = dataGridView1.Rows[i].Cells[0].Value;
        var src2 = dataGridView2.Rows[i].Cells[0].Value;
        result = Convert.ToInt32(src1) - Convert.ToInt32(src2);
    
        row["Result"] = result;
        dt.Rows.Add(row);
    }
    re.dgvFinal = new DataGridView();
    re.dgvFinal.DataSource = dt;
    re.Show();
