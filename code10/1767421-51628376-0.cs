    var previous = Find_Previous_Entity();
    // Find list differences from the database entity (you may need a comparer)
    var added = entity.OneToManyList.Except( previous.OneToManyList );  // ToList() optional but very recommended
    var deleted = previous.OneToManyList.Except( entity.OneToManyList );  // Same as above
    
    // Make the appropriate changes
    foreach( var item in deleted )
    {
        item.TheForeignKey = null;  // Foreign key related with the entity
        myContext.Entry(item).State = EntityState.Modified;
    }
    foreach( var item in added )
    {
        item.TheForeignKey = entity.ThePrimaryKey;
        myContext.Entry(item).State = (item.Id == 0) ? EntityState.Added : EntityState.Modified;
    }
