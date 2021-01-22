    public static void InsertIfNotExists<TEntity>
                        (this Table<TEntity> table
                         , TEntity entity
                        ) where TEntity : class
        {
            if (!table.Contains(entity))
            {
                table.InsertOnSubmit(entity);
                
            }
        }
