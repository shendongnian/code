    DataTable dt = FetchTableFromDatabase();
    
    List<Car> lst = new List<Car>();
    
    lst = (from DataRow row in dt.Rows
                               select new Car
                               {
                                   ID = (int)row["ID"],
                                   CarName = row["CarName"].ToString()
                               }).ToList();
    private DataTable FetchTableFromDatabase()
    {
    	DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Your connectionString");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_cars", con);
        
            try
            {
          	     SqlDataAdapter da = new SqlDataAdapter(cmd);
                 da.Fill(dt);
                 return dt;
            }
            catch (Exception ex)
            {
                 throw ex;
            }
            finally
            {
                 con.Close();
                 con.Dispose();
            }
    }
