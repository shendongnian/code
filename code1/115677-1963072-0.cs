    DateTime start = DateTime.Now;
    DateTime end = start.AddDays(3);
    string sql = @"
    SELECT * FROM Forecast
    WHERE City = @City AND Date BETWEEN @StartDate AND @EndDate";
    // Don't forget to close this somewhere. Why not create a new connection
    // and dispose it?
    Con.Open();
    using (SqlCommand command = new SqlCommand(sql, Con))
    {
        command.Parameters.Add("@City", SqlDbType.NVarChar).Value = city;
        command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = start;
        command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = end;
        using (SqlDataReader reader = command.ExecuteReader())
        {
            int i = 0;
            while (reader.Read())
            {
                //do something
                i++;
            }
        }
    }
