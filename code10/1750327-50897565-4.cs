    using (var command = new SqlCommand("SELECT City FROM Cities WHERE Postcode=@Postcode", connection))
    {
        command.Parameters.AddWithValue("@Postcode", "10101");
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string txt_st_postalcode = reader[0] as string;
                //txt_st_city.Text = reader.GetString(reader.GetOrdinal("City"));
                // Depends what you're doing here?
            }
        }
    }
