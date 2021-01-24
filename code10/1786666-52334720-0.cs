    private void MyDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      vID = MyDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
      Form2 NewForm = new Form2(vID);
      this.Close();
      NewForm.Show();
    }
