    // Note that this looks like a mixture of UI and non-UI code; consider separating
    // them for greater code reuse, separation of concerns etc.
    private void button1_Click(object sender, EventArgs e)
    {
        // Declare connectionString elsewhere
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("select top 50 trip_ID from Sayfa1$", connection))
            {
                using (var reader = command.ExecuteReader())
                {    
                    while (reader.Read())
                    {
                        gecici.Add(oku["trip_ID"].ToString());
                    }
                }
            }
        }
    }
