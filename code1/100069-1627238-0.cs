    var customerDictionary = new Dictionary<Customer,string>();
    foreach( var cust in customers )
    {
        if( !customerDictionary.ContainsKey(cust) )
            customerDictionary.Add( cust, cust.SomeKey ); 
    }
