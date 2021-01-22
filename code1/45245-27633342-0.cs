    Database----->:
    create proc MySP
    @a varchar(50),
    @b varchar(50) output
    AS
    SET @Password = 
    (SELECT Password
    FROM dbo.tblUser
    WHERE Login = @a)
    C# ----->:
     
    SqlConn.Open();
    sqlcomm.CommandType = CommandType.StoredProcedure;
    
    SqlParameter param = new SqlParameter("@a", SqlDbType.VarChar);
    param.Direction = ParameterDirection.Input;//This is optional because Input is the default
    
    param.Value = Username;
    sqlcomm.Parameters.Add(param);
    
    SqlParameter outputval = sqlcomm.Parameters.Add("@b", SqlDbType.VarChar);
    outputval .Direction = ParameterDirection.Output//NOT ReturnValue;
    
    
    string outputvalue = sqlcomm.Parameters["@b"].Value.ToString();
