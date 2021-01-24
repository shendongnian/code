    private void Btn_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO [Account] ([Nick],[Password]) values (?,?);";
			// note that order is critical here
			command.Parameters.Add(new OleDbParameter("@nick", OleDbType.VarChar)).Value = NickEnter.Text;
			command.Parameters.Add(new OleDbParameter("@password", OleDbType.VarChar)).Value = PassEnter.Text;
			
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error! | " + ex, "Error!");
        }
    }
