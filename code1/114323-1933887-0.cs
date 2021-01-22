    string connString = "<your connection string>";
    string sql = "name of your sp";
    
    SqlConnection conn = new SqlConnection(connString);
    
    try {
       SqlDataAdapter da = new SqlDataAdapter();
       da.SelectCommand = new SqlCommand(sql, conn);
       da.SelectCommand.CommandType = CommandType.StoredProcedure;
       DataSet ds = new DataSet();   
       da.Fill(ds, "result_name");
    
       DataTable dt = ds.Tables["result_name"];
    
       foreach (DataRow row in dt.Rows) {
                   //manipulate your data
       }
                
    } catch(Exception e) {
       Console.WriteLine("Error: " + e);
    } finally {
       conn.Close();
    }
