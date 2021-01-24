    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        connection.Open();
    	using (SqlTransaction transaction = connection.BeginTransaction())
    	{
    		using (SqlCommand cmd = new SqlCommand("PP_CreateSheet", connection, transaction))
    		{
    			// First command
    		}
    		using (SqlCommand comm = new SqlCommand("PP_CreateNumber", connection, transaction))
    		{
    			// Second command
    			// .. omitted
    			if(!int.TryParse(value, out parsedValue)){
    				lblError.Text = "Please enter only numeric values for number";
    				return; // Since we haven't committed the transaction, it will be rolled back when disposed.
    			}
                // .. omitted
    		}
    		transaction.Commit(); // Both commands execute without error, commit the transaction.
    	}
    }
