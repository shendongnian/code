    public static void InsertIfNotExists<TEntity>
                        (this Table<TEntity> table,
                         TEntity entity,
                         Expression<Func<TEntity,bool>> predicate)
        where TEntity : class
    { 
        if (!table.Any(predicate)) 
        {
            table.InsertOnSubmit(record);
            table.Context.SubmitChanges();
        }
     }
    table.InsertIfNotExists(entity, e=>e.BooleanProperty);
