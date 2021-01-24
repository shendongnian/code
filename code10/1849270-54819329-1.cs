            string sqlQuery = @"
    IF NOT EXISTS(SELECT 1 FROM Client WHERE [ClientID] = @ClientID)
    BEGIN
        INSERT INTO Client (ClientId, LastName, FirstName, UpdateType)
        VALUES (@ClientID, @LastName, @FirstName, 1)
    END
    ELSE
    BEGIN
        UPDATE Client SET 
            [LastName] = @LastName,
            [FirstName] = @FirstName,
            [UpdateType] = 2
        WHERE
            ClientID = @ClientID;//<<<fix your query!!!!!
    END;
    
    using (SqlCommand MyCommand = new SqlCommand(sqlQuery, SQLConn))
    {
        MyCommand.Parameters.Add("@ClientID", SqlDbType.VarChar);
        MyCommand.Parameters.Add("@LastName", SqlDbType.VarChar);
        MyCommand.Parameters.Add("@FirstName", SqlDbType.VarChar);
    
        try{
            SQLConn.Open();
            foreach (DataRow row in SourceData.Rows)
            {
                MyCommand.Parameters["@ClientID"].Value = row["ClientId"].ToString();
                MyCommand.Parameters["@LastName"].Value = row["LastName"].ToString();
                MyCommand.Parameters["@FirstName"].Value = row["FirstName"].ToString();
            }
         }catch{
             ....
         }    
    }
