    List<int> userIdList;
	using (var con = new SqlConnection(Properties.Settings.Default.ConnectionStr))
	{
        using(var command = new SqlCommand("Select userid from UserProfile where grpid=@id", con))
        {
           command.Parameters.AddWithValue("@id", id);
	       con.Open();
		   using (SqlDataReader rd = command.ExecuteReader())
			  userIdList = rd.ToList<int>();
		}
	}
