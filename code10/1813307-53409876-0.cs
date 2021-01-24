    public void connect(){
             string connectionString =
                 "Server=servername;" +
                 "Database=dbname;" +
                 "User ID=userid;" +
                 "Password=pass;" +
                 "Integrated Security=True";
             
             result = new List<float> ();
             resultCas = new List<DateTime> ();
     
             using(SqlConnection conn = new SqlConnection(connectionString))
             {
                 SqlCommand c; SqlDataReader da; SqlParameter param1; SqlParameter param2; SqlParameter param3; SqlParameter param4;
                  conn.Open();
                 c = new SqlCommand();
                 c.Connection = conn;
                 c.CommandType = CommandType.StoredProcedure;
                 c.CommandText = "commandtext";
                 param1 = c.Parameters.Add("@identify",SqlDbType.Int);        
                 param1.Value = 1;
                 param2 = c.Parameters.Add("@startTime",SqlDbType.DateTime);
                 param2.Value = "2010-11-10 07:45:00.000";
                 param3 = c.Parameters.Add("@endTime",SqlDbType.DateTime);
                 param3.Value = "2010-11-12 10:15:00.000";
                 param4 = c.Parameters.Add("@args",SqlDbType.NVarChar);
                 param4.Value = "I";
                 da = c.ExecuteReader();
                 while (da.Read())
                 {
                     resultCas.Add(da.GetDateTime(0));
                     result.Add((float)da.GetDouble(1));
                 }
             }
         }
