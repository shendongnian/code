    using (SqlCommand loadbonus = new SqlCommand("Client_Update", conn))
    {
        loadbonus.CommandType = CommandType.StoredProcedure;
        loadbonus.Parameters.Add("@NComptoir", SqlDbType.Int).Value = tabcontrol.SelectedIndex;
        int restantbonus = Convert.ToInt32(loadbonus.ExecuteScalar());
        if (restantbonus <= 0)
        {
        }
    }
