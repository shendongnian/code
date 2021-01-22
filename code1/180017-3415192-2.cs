    public DataSet Select() 
    { 
      SqlConnection sqlConnection1 = new SqlConnection(); 
      string SqlString = "select * from Categories"; 
      SqlDataAdapter da=new SqlDataAdapter(SqlString,ConnectionStrings.StaceysCakes); 
      DataSet ds = new DataSet(); 
      da.Fill(ds, "Categories"); 
      return (ds); 
    } 
