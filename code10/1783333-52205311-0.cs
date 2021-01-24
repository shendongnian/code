    public static DataTable GetAddressStatusOfDevice(string deviceId, string connectionString)
    {
    	string commandText = "SELECT AddressStatus FROM dbo.DeviceAddresses WHERE DeviceID = @ID;";
    	var dt = new DataTable();
    	var da = new SqlDataAdapter(commandText, connectionString);
    	da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = deviceId;
    	da.Fill(dt);
    	return dt;
    }
