    private void button4_Click(object sender, EventArgs e)
    {
    con.Open();
    SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Table] SET 
          [First] = @first,
          [Last] = @last, 
          [Email] = @email,
          [Category] = @cat
      WHERE (Mobile=@mobile)", con);
   
    cmd.Parameters.Add("@first", SqlDbType.VarChar).Value = textBox1.Text;
    cmd.Parameters.Add("@last", SqlDbType.VarChar).Value = textBox2.Text;
    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox4.Text;
    cmd.Parameters.Add("@cat", SqlDbType.VarChar).Value = comboBox1.Text;
    cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = textBox3.Text;
    cmd.ExecuteNonQuery();
    con.Close();
    MessageBox.Show("Updated Successfully");
    display();
    }
