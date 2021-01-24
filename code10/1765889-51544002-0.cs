    public int GetRate()
    {
    	int i = -1; // an impossible value
    	try
    	{
    		using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=RatesDB;Integrated Security=True"))
    		using (SqlCommand cmd = new SqlCommand(@"select top(1) HeartRate 
                       from Rates 
                       order by HeartRate DESC", connection))
    		{
    			connection.Open();
    			i = Convert.ToInt32(cmd.ExecuteScalar());
    			connection.Close();
    		}
    	}
    	catch
    	{ }
    	return result;
    }
