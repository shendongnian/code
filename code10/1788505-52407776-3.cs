	public void CallConvert()
	{
    	// get the data from DB in list
        List<Input> inputs = new List<Input>();
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "dbo.ReadAll_Input";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        inputs.Add(MapRow(dr));
                    }
                }
            }
        }
        var output=Test.Convert(inputs.ToArray());
	}
