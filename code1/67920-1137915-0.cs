    // The SQL connection object to connect to the database. Takes connection string.
    SqlConnection connection = 
        new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Example");
    // Idealy you wouldnt pass direct SQL text for injection reasons etc, but
    // for example sake I will enter a simple query to get some dates from a table.
    // Notice the command object takes our connection object...
    SqlCommand command = new SqlCommand("Select [Date] From Dates", connection);
    // Open the connection
    connection.Open();
    // Execute the command
    SqlDataReader reader = command.ExecuteReader();
    // A list of dates to store our selected dates...
    List<DateTime> dates = new List<DateTime>();
    // While the SqlDataReader is reading, add the date to the list.
    while (reader.Read())
    {
        dates.Add(reader.GetDateTime(0));
    }
    // Close the connection!
    connection.Close();
    // Use the selected dates property of the ASP.NET calendar control, add every
    // date that we read from the database...
    foreach (DateTime date in dates)
    {
        Calendar1.SelectedDates.Add(date);
    }
