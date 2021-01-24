    public void Update<T>(T entity) where T : IIdentity
    {
        if(entity.Id == ObjectId.Empty)
        {
            entity.Id = ObjectId.GenerateNewId();
        }
        collection.ReplaceOne(x => x.Id == entity.Id, entity, new UpdateOptions() { IsUpsert = true } );
    }
