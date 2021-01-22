    var query = myEntities.MyEntity
                         .Select(e => e.Name)
                         .Where(e => e.IsIn("inclusion1", "inclusion2"));
    var query = myEntities.MyEntity
                         .Select(e => e.Name)
                         .Where(e => e.IsNotIn("exception1", "exception2"));
