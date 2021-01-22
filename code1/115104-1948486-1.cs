    Table<TEntity> da = MyDataContext.Context.GetTable<TEntity>();
    
    if (entity.Id > 0)
        da.Attach(entity, true);
    
    else
        da.InsertOnSubmit(entity);
    
    da.Context.SubmitChanges();
