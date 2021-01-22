    static void EnsureInsertedOnSubmit<TEntity>( this Table<TEntity>  table
                                                ,IEnumerable<TEntity> entities)
     { foreach(var entity in entities) 
        { if  (   table.GetModifiedMembers(entity).Length == 0     
               && table.GetOriginalEntityState(entity) == default(TEntity))
           { table.InsertOnSubmit(entity);
           }
        }
     }
