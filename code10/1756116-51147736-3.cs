     public List<string> GetTableColumns(string tableName)
     {
       if(!String.IsNullOrWhiteSpace(tableName))
       {
        string query = string.Format( "SELECT * FROM  [{0}]",tableName);
        // or use string interpolation
        string query = $"SELECT * FROM [{tableName}]";
        //rest of the code execute reader  
        //return collection of string   
       }
       return new List<string>();
      }
