    session.Save(someEntity);
    session.Flush(); // forces the entity to be inserted
    session.Clear(); // clears the session's identity map, thus
                     // detaching someEntity from the session
    
    var loadedEntity = session.Get<EntityType>(someEntity.Id);
    
    // now you may compare the fields of someEntity and loadedEntity
    // to verify that they were actually persisted
