    public void Update<T>(T entity) where T : IIdentity
    {
        if(entity.Id == ObjectId.Empty)
        {
            collection.InsertOne(entity); // driver creates _id under the hood
        }
        else
        {
            collection.ReplaceOne(x => x.Id == entity.Id, entity, new UpdateOptions() { IsUpsert = true } );
        }
    }
