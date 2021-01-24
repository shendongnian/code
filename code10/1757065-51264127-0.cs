    var list = new List<MY_ENTITY> ();
    
    var query = from myEntity in entities.MY_ENTITIES 
    			select new MY_ENTITY
                {
                    ID = myEntity.Id,
                    // all other myEntity properties that I want to avoid setting manually
                    NotMappedProperty = null,  //    --> we will set this later
    				joinEntityIdToJoinTo = joinEntity.ID
                };;
    
    var joinedObjectsQuery = from myEntity in entities.JOIN_ENTITIES;
                
    foreach (var entity in query) 
    {
    	list.Add( new MY_ENTITY {
    		ID = entity.ID,
    		NotMappedProperty = joinedObjectsQuery.Single(x=>xID == entity.joinEntityIdToJoinTo)
    	})
    }
    			
