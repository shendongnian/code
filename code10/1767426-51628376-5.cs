    var previous = Find_Previous_Entity();
    // Find list differences from the database entity (you may need a comparer)
    var added = entity.ManyToManyList.Except( previous.ManyToManyList );  // ToList() optional but very recommended
    var deleted = previous.ManyToManyList.Except( entity.ManyToManyList );  // Same as above
    // Restore the current list to the value held in the database
    entity.ManyToManyList.Clear();
    foreach( var item in previous.ManyToManyList )
    {
        // You may want to insert the line below to avoid attaching both the previous entity and the current one to the context, it gets messy then
        item.OtherManyToManyList.Remove(previous);
        entity.ManyToManyList.Add(item);
    }
    // The new entity now has a copy of the previous list
    //Attach the entity with the previous list
    myContext.Set<ClassOfEntity>().Attach(entity);
    // Entity Framework will now acknowledge the changes made in the list and automatically create the appropriate relationships
    foreach( var item in deleted )
    {
        entity.ManyToManyList.Remove(item);
        myContext.Entry(item).State = EntityState.Modified;
    }
    foreach( var item in added )
    {
        entity.ManyToManyList.Add(item);
        myContext.Entry(item).State = (item.Id == 0) ? EntityState.Added : EntityState.Modified;
    }
