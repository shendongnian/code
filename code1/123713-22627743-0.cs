    try
    {
     con.Open();
     
     foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
     {
      OleDbCommand cmd = new OleDbCommand(cmdTxt, con);
      cmd.Parameters.AddWithValue("kurs", c2);
      cmd.Parameters.AddWithValue("ID", item.Cells[0].Value);
      cmd.ExecuteNonQuery();
     }
    }
    catch (Exception exception)
    {
     MessageBox.Show(exception.Message);
    }
    finally
    {
     con.Close();
    }
