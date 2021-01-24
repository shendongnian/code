     using (SqlCommand command = new SqlCommand("SELECT * FROM [Sheet1$] WHERE [ONE COLUMN NAME]=@col1 AND [2nd COLUMN NAME]=@col2",conn)
     {
     command.Parameters.Add("@col1",OledbType.VarChar).Value = txtbx1.Text;
     command.Parameters.Add("@col2",OledbType.VarChar).Value = txtbx2.Text;
     SqlDataReader dr = command.ExecuteReader;
     DataGridView1.Rows.Clear();
     while (dr.read)
     {
      DataGridViewRow row =  (DataGridViewRow)yourDataGridView.Rows[0].Clone();
      row.Cells[0].Value = "XYZ";
      row.Cells[1].Value = 50.2;
      DataGridView1.Rows.Add(row);
      }}}
