        if (!string.IsNullOrEmpty(Mpdue.TheObjectPropertyNameNs))
        {
            var paramValue = string.Join(", ", Mpdue.TheObjectPropertyNameNs);
    
            string sql = string.Format("SELECT * FROM doTable WHERE dOCode IN ({0})", paramValue.ToString());
    
            ...
    
            foreach (var param in paramValue)
            {
               command.Parameters.AddWithValue("param1", param.ToString());
            }
            
            ...
       }
