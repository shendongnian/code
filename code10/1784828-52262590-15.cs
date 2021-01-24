    private void a_KeyDown(object sender, KeyEventArgs e)
    {
        using (var con = new MySqlConnection(connectString))
        using (var cmd = new MySqlCommand("thamer1", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@main_items_id_", MySqlDbType.Int32).Value = a.Text;
            cmd.Parameters.Add("@res", MySqlDbType.Int32).Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteNonQuery();
            HITEM.Text = cmd.Parameters["@res"].Value;
        }
    }
