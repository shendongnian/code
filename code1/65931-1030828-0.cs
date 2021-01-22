    SqlDataReader dr = cmd.ExecuteReader(); // where cmd is a SqlCommand
    
    List<SomeType> items = new List<SomeType>(1000);
    
    while(dr.Read()) {
      // read the values for the row
      SomeType obj = new SomeType(dr["id"], dr["value"], ...);
      
      // add the object to the list
      items.Add(obj);
    
      // when the list is full, process it, and create a new one.
      if(items.Count >= 1000) {
        Process(items);
        items = new List<SomeType>(1000);
      }
    }
      
