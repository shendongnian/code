          predicate = PredicateBuilder.True(query);
    foreach(var item in repids)
       { 
    
          if (typeid == "3")
          {
           predicate = predicate.And(z => ids.Contains(z.ProductTypeId.ToString()) && 
                   z.CreatedDate == Convert.ToDateTime(fromDate));                            
          }
