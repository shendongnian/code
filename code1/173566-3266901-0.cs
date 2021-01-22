    public static void LockRow<TEntity>(int TablePrimaryKey) where TEntity : class
        {
            using (var context = McpDataContext.Create())
            {
                var tableToLock = (from lockTable in context.GetTable<TEntity>()
                                   where lockTable.PlanID == TablePrimaryKey
                                   select lockTable).Single();
    
                tableToLock.Locked = true;
                context.SubmitChanges();
            }
        }
