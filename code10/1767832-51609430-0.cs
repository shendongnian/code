    private void BtnOk_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE [Users] SET [User] = ?, [Password] = ?, [IsAdmin] = ? WHERE ID = ?";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            var accessUpdateCommand = new OleDbCommand(query, conn);
            accessUpdateCommand.Parameters.AddWithValue("User", txtUser.Text);
            accessUpdateCommand.Parameters.AddWithValue("Password", txtPass.Text);
            accessUpdateCommand.Parameters.AddWithValue("IsAdmin", chBAdmin.Checked);
            accessUpdateCommand.Parameters.AddWithValue("ID", txtID.Text);
            adapter.UpdateCommand = accessUpdateCommand;
            adapter.UpdateCommand.ExecuteNonQuery();
            conn.Close();
        }
