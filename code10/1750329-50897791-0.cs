    if (reader.Read())
    {
        txt_st_postalcode .Text = reader.GetString(reader.GetOrdinal("PostCode"));
        txt_st_city.Text = reader.GetString(reader.GetOrdinal("City"));
    }
    else
    {
        MessageBox.Show("Sh*t!");
    }
