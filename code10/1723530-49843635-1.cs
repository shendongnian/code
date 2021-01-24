      private void datagridview1_KeyDown()
        if (e.KeyCode == Keys.Enter)
          {
           int rowindex = dataGridView1.CurrentCell.RowIndex; //Here we get the selected row's index of the dataGridView
           int columnindex = dataGridView1.CurrentCell.ColumnIndex; ////Here we get the selected column's index of the dataGridView
           SqlCommand cmd = new SqlCommand("Select * from tablename WHERE desc=@desc",connection);
           cmd.Parameters.Add("@desc",SqlDbType.VarChar).Value = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();
           SqlDataReader dr = cmd.ExecuteReader();
           While (dr.Read())
            {
              dataGridView1.Rows[rowindex].Cells[1].Value = dr[1].ToString
             ///Keep continuing for each column
            }
           dr.Close();
           }
