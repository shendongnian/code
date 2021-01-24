    EntityA primaryEntity = new EntityA() { //initialise me... };
    EntityB secondaryEntity = new EntityB() { //initialise me... };
    context.AddObject(primaryEntity);
    context.AddObject(secondaryEntity);
    
    // This is the key part: explicitly link the two entities
    context.AddLink(primaryEntity, 
        new Relationship("relationship_name_here"), secondaryEntity);
    
    // commit changes to CRM
    context.SaveChanges();
