    private void a_KeyDown(object sender, KeyEventArgs e)
    {
        //You can re-use the *names* of these variables, since the scope of the variable is limited to the method
        //You can also stack them to share the same scope block and reduce nesting/indentation
        using (var con = new MySqlConnection(connectString))
        using (var cmd = new MySqlCommand("thamer1", con))
        {
            mysqlcmd6.CommandType = CommandType.StoredProcedure;
            //  mysqlcmd6.CommandText = "thamer1"; //you already did this in constructor. Don't need to do it again
            mysqlcmd6.Parameters.Add("@main_items_id_", MySqlDbType.Int32).Value = a.Text;
            mysqlcmd6.Parameters.Add("@res", MySqlDbType.Int32);
            //wait as long as possible to call Open()
            con.Open();
            cmd.ExecuteNonQuery();
            
            //Now you can assign **to** HITEM.Text, rather than from it.
            HITEM.Text = cmd.Parameters["@res"].Value;
           // MessageBox.Show("saved");
            // GridFill();
        }
    }
