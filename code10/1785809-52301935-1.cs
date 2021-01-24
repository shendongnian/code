    DataSet ds = new DataSet();
    using (SqlConnection conn =	new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
    using (SqlCommand cmd = new SqlCommand("EXEC p_MultipleResultsProc", conn))
  	using (SqlDataAdapter da = new SqlDataAdapter(cmd))
   	{
   		da.Fill(ds);
   	}
