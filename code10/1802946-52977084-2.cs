    public static class RawBsonDocumentHelper
    {
        public static RawBsonDocument FromBsonDocument(BsonDocument document)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var bsonWriter = new BsonBinaryWriter(memoryStream, BsonBinaryWriterSettings.Defaults))
                {
                    var context = BsonSerializationContext.CreateRoot(bsonWriter);
                    BsonDocumentSerializer.Instance.Serialize(context, document);
                }
                return new RawBsonDocument(memoryStream.ToArray());
            }
        }
        public static RawBsonDocument FromJson(string json)
        {
            return FromBsonDocument(BsonDocument.Parse(json));
        }
    }
