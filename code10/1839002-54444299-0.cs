    public class SeqIntIdGenerator<TEntity, TDocument> : IIdGenerator
    {
        public static SeqIntIdGenerator<TEntity, TDocument> Instance { get; } = new SeqIntIdGenerator<TEntity, TDocument>();
        public object GenerateId(object container, object document)
        {
            var idSequenceCollection = ((IMongoCollection<TDocument>)container).Database.GetCollection<dynamic>("Counters");
            var filter = Builders<dynamic>.Filter.Eq("_id", ((IMongoCollection<TDocument>)container).CollectionNamespace.CollectionName);
            var update = Builders<dynamic>.Update.Inc("Seq", 1);
            var options = new FindOneAndUpdateOptions<dynamic>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };
            return idSequenceCollection.FindOneAndUpdate(filter, update, options).Seq;
        }
        public bool IsEmpty(object id)
        {
            return (int)id == 0;
        }
    }
