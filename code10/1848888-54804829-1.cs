    SqlConnection objConn = new SqlConnection(connectionString);  
    objConn.Open();  
    SqlCommand objCmd = new SqlCommand("Select * From MyImageDatabaseTable", objConn);  
    SqlDataReader dr = objCmd.ExecuteReader();  
    while(dr.Read())
    {
         byte[] myImageByteArrayData = (byte[]) dr["BLOBData"];  
    
         string myImageBase64StringData = Convert.ToBase64String(myImageByteArrayData );
    }
