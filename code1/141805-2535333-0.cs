    // Initialize Indexes
    dbConfig.Common.ObjectClass(typeof(DAObs.Environment))
        .ObjectField("<Key>k__BackingField").Indexed(true);
    dbConfig.Common.Add(new Db4objects.Db4o.Constraints.
        UniqueFieldValueConstraint(typeof(DAObs.Environment), "<Key>k__BackingField"));
 
