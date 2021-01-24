    public int ApproveReq(ref Dataset result)
            {
                string strConn = ConfigurationManager.ConnectionStrings
                                 ["StudentEPortfolioConnectionString"].ToString();
    
                // Instantiate a SqlCOnnection object with the connection string read.
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("UPDATE ViewingRequest " +
            "SET Status = 'A' WHERE ViewingRequestID = @selectedViewingRequestID ", conn);
    cmd.parameters.add("@selectedViewingRequestID",Pass_selectedid);
    
                SqlDataAdapter daRequest = new SqlDataAdapter(cmd);
                DataSet requests = new DataSet();
    
                conn.Open();
                daRequest.Fill(requests, "viewingRequest");
                conn.Close();
    
                return 0;
            }
