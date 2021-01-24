    if (e.KeyCode == Keys.Enter)
    {
      SqlCommand sqlcmd = new SqlCommand("SELECT ID FROM X WHERE ID=" + dataGridView1.CurrentRow.Cells[0].Value + "", sqlcon);
      SqlDataReader sqldr = sqlcmd.ExecuteReader();
      while (sqldr.Read())
      {
       string CodeTextBox = sqldr[codecolumn].Tostring;
       string NameTextBox = sqldr[Namecolumn].Tostring;
       string BlahTextBox = sqldr[Blahcolumn].Tostring;
       Form1 frm = new Form1(CodeTextBox, NameTextBox, BlahTextBox);
      }
    }
