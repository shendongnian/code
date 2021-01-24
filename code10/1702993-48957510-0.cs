        public string DoGenericAggregate(string queryDoc, string collectionName)
        {
            var query = BsonSerializer.Deserialize<BsonDocument[]>(queryDoc).ToList();
            List<BsonDocument> list;
            using (var cursor = _context.Database.GetCollection<dynamic>(collectionName).Aggregate<BsonDocument>(query))
            {
                list = cursor.ToList();
            }
            if (list == null)
                return null;
            else
                return list.ToJson();
        }
