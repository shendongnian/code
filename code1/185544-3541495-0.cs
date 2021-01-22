    if(FU2.PostedFile.ContentLength == 0) 
    {
        SqlParameter UploadedImage2 = new SqlParameter("@Logo", SqlDbType.VarABinary, System.DBNull.Value);
        Com.Parameters.Add(UploadedImage2);
    }
    
