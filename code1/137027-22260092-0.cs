    MyLinqToSQLTable.Where(x =>  
    {   
        return x.objectID == paramObjectID;  
    }).ToList();  
    or
    MyLinqToSQLTable.Where(x =>  
    {   
        return x.objectID == paramObjectID;  
    }).ToArray();
  
