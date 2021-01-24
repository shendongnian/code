    public static bool sendXMLToSqlServer(string procedure,string xmlData)
    {
        var status = false;
        try
        {
            using (SqlConnection con = new SqlConnection(@"<your connection string goes here>"))
            {
                con.Open();
                var com = new SqlCommand();
                com.CommandText = procedure;
                com.Connection = con;
                com.Parameters.Add(new SqlParameter("@data",xmlData));
                com.CommandType = System.Data.CommandType.StoredProcedure;
                //i am using the dataAdapter approach to get the data from the procedure you can write your own code to read the output from the procedure
                var ds = new DataSet();
                var da = new SqlDataAdapter(com);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) //check if there is any record from 
                    status = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return status;
    }
