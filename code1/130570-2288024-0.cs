    <WebMethod()> Public sub AddRecord(id as integer, name as string)
    
    dim sSql as string = "INSERT INTO Btable (ID, Name) VALUES (@ID, @Name)"    
    Dim oCmd as SqlCommand = nwindConn.CreateCommand()
    oCmd.CommandText = sSql
    oCmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
    oCmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = name
    oCmd.ExecuteNonQuery()
    
    End Function 
