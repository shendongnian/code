    Type GetNETType(string sqlType)
    {
        if(sqlToNetTypes.ContainsKey(sqlType))
        {
            return sqlToNetTypes[sqlType];
        }else
        {
            return typeof(object); //generic type
        }
    }
