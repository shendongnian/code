    private void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            // Notice how Group field is between square brackets.
            // If you can I suggest to change the name of this field
            Dim cmdText = "insert into GRL1 (NoBoard,Site,[Group],Kind,Unit) " & _ 
                          "values (@nob, @sit, @grp, @knd, @uni)";
            command.CommandText = cmdText;
            // Is NoBoard an integer? If yes you should pass an integer not a string
            command.Parameters.Add("@nob", OleDbType.Integer).Value = Convert.ToInt32(txt_noboard.Text);
            command.Parameters.Add("@sit", OleDbType.VarWChar).Value = txt_site.Text;
            command.Parameters.Add("@grp", OleDbType.VarWChar).Value = txt_group.Text;
            command.Parameters.Add("@knd", OleDbType.VarWChar).Value = txt_kind.Text;
            command.Parameters.Add("@uni", OleDbType.VarWChar).Value = txt_unit.Text;
            command.ExecuteNonQuery();
            MessageBox.Show("Data Saved");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error  " + ex);
        }
    }
