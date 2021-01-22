    String username;
    String pwd;
    
    int columnIndex = reader.GetOrdinal("username");
    
    if (!dataReader.IsDBNull(columnIndex))
    {
    	username = dataReader.GetString(columnIndex);
    }
    
    columnIndex = reader.GetOrdinal("pwd");
    
    if (!dataReader.IsDBNull(columnIndex))
    {
    	pwd = dataReader.GetString(columnIndex);
    }
