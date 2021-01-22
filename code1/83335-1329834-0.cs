    var query = (from p in products
                 select p);
    
    if(field1 != null)
    {
        query = (from p in query
                 where p.Field1 = field1
                 select p);
    }
    
    if(field2 != null)
    {
        query = (from p in query
                 where p.Field2 = field2
                 select p);
    }
    
    foreach(Product p in query)
    {
       // ...
    }
