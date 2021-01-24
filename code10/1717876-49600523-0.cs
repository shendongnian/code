    String query = "INSERT INTO rents VALUES (@renterName, @rentStartDate, @rentEndDate); SELECT CAST(SCOPE_IDENTITY() AS INT)";
    Int32 lastId = 0;
    using(f1.Connection = new SqlConnection(f1.connectionString))
    using(SqlCommand command = new SqlCommand(query, f1.Connection))
    {
        f1.Connection.Open();
        command.Parameters.AddWithValue("@renterName", rentNameBox.Text);
        command.Parameters.AddWithValue("@rentStartDate", DateTime.Now);
        command.Parameters.AddWithValue("@rentEndDate", rentEndDatePicker.Value);
        lastId = (Int32)command.ExecuteScalar();
    }
