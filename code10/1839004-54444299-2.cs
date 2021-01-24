    public object GenerateId(object container, object document)
    {
        var containerDynamic = (dynamic) container;
        var idSequenceCollection = containerDynamic.Database.GetCollection<dynamic>("Counters");
        var filter = Builders<dynamic>.Filter.Eq("_id", containerDynamic.CollectionNamespace.CollectionName);
        var update = Builders<dynamic>.Update.Inc("Seq", 1);
        var options = new FindOneAndUpdateOptions<dynamic>
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After
        };
        return idSequenceCollection.FindOneAndUpdate(filter, update, options).Seq;
    }
