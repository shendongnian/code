        private void AddButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AddEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", SqlDbType.VarChar).Value = textBox1.Text.Trim();
            cmd.Parameters.AddWithValue("@name", SqlDbType.VarChar).Value = textBox2.Text.Trim();
            cmd.Parameters.AddWithValue("@address", SqlDbType.VarChar).Value = textBox3.Text.Trim();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee added");
            con.Close();
        }
