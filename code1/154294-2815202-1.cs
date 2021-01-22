    Public void InsertEntity(Entity entity)
    {
        dataContext.Entities.InsertOnSubmit(entity);
        dataContext.SubmitChanges();
    }
