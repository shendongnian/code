    string strQuery = "sp_SaveFile";
    
    SqlCommand cmd = new SqlCommand(strQuery);
    cmd.CommandType = CommandType.StoredProcedure;
    
    cmd.Parameters.Add("@FormId", SqlDbType.Int).Value = fileId;
    if(bytes1 != null)
        cmd.Parameters.Add("@Blob1", SqlDbType.Binary).Value = bytes1;
    if(bytes2 != null)
        cmd.Parameters.Add("@Blob2", SqlDbType.Binary).Value = bytes2;
    // .... Handle rest of the Blob parameters.
    
    InsertUpdateData(cmd);
