    public DataSet Select() 
    { 
      using(SqlDataAdapter da = new SqlDataAdapter(
                                "select * from Categories",
                                ConnectionStrings.StaceysCakes))
      {
          DataSet ds = new DataSet(); 
          da.Fill(ds, "Categories"); 
          return ds;
      }
    }
