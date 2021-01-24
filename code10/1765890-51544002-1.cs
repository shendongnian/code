    public List<int> GetRates()
    {
    	var result = new List<int>();
    	try
    	{
    		using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=RatesDB;Integrated Security=True"))
    		using (SqlCommand cmd = new SqlCommand(@"select HeartRate 
                       from Rates 
                       order by HeartRate DESC", connection))
    		{
    			connection.Open();
    			var rdr = cmd.ExecuteReader();
    			while (rdr.Read())
    			{
    				result.Add((int)rdr[0]);
    			}
    			connection.Close();
    		}
    	}
    	catch
    	{ }
    	return result;
    }
