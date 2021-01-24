    [WebMethod]
    public Airline_Flights[] Loadetails(string StuID)
    {
        var flightsList = GetFlightListByStuID(string StuID);
        return selectedFlights.Select(x => x.FlightNo).ToArray();
    }
    // could be in another data access class etc.
    private List<Airline_Flights> GetFlightListByStuID(string StuID)
    {
        List<Airline_Flights> selectedFlights = new List<Airline_Flights>();
        string connectionString = ConfigurationManager.ConnectionStrings["BriskCargo"].ConnectionString;
        // SQL with parameter
        string commandString = @"
           SELECT FlightNo 
           FROM AirLine_Flights 
           WHERE ALCode = @StuID AND IsActive=1
          ";
        // use IDisposable here so it closes and garbage collects automatically
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(commandString))
            {
                // check the length and type here...
                command.Parameters.Add("@StuID",SqlDbType.NVChar, 25).Value = StuID; 
                command.CommandType = CommandType.Text;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       flightsList.Add(new Airline_Flights{ FlightNo= reader["FlightNo"].ToString()});
                    }
                }
            }  
        }
        return selectedFlights;
    }
