    private void a_KeyDown(object sender, KeyEventArgs e)
    {
        //You can re-use the *names* of these variables, since their scopes are limited to the method
        //You can also stack them to share the same scope block and reduce nesting/indentation
        using (var con = new MySqlConnection(connectString))
        using (var cmd = new MySqlCommand("thamer1", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            //  mysqlcmd6.CommandText = "thamer1"; //you already did this in constructor. Don't need to do it again
            cmd.Parameters.Add("@main_items_id_", MySqlDbType.Int32).Value = a.Text;
            //DON'T assign to the Value, but DO make sure ADO.Net understands this is an OUTPUT parameter
            cmd.Parameters.Add("@res", MySqlDbType.Int32).Direction = ParameterDirection.Output;
            //wait as long as possible to call Open()
            con.Open();
            cmd.ExecuteNonQuery();
            
            //Now you can assign **to** HITEM.Text, rather than from it.
            HITEM.Text = cmd.Parameters["@res"].Value;
        }
        //End the scope as soon as possible, so the connection can be disposed faster
        // MessageBox.Show("saved");
        // GridFill();
    }
