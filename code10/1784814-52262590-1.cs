    private void a_KeyDown(object sender, KeyEventArgs e)
    {
        using (var con = new MySqlConnection(connectString))
        using (var cmd = new MySqlCommand("thamer1", con))
        {
            mysqlcmd6.CommandType = CommandType.StoredProcedure;
            mysqlcmd6.Parameters.Add("@main_items_id_", MySqlDbType.Int32).Value = a.Text;
            mysqlcmd6.Parameters.Add("@res", MySqlDbType.Int32);
            con.Open();
            cmd.ExecuteNonQuery();
            HITEM.Text = cmd.Parameters["@res"].Value;
        }
    }
