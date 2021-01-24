      public void Upsert(Person person)
        {
            var fiterBuilder = Builders<BsonDocument>.Filter;
            var escapedFirstname = fiterBuilder.Eq("firstname", "\\1");
            var escapedLastname = fiterBuilder.Eq("lastname", "\'");
            var filter = fiterBuilder.And(escapedFirstname, escapedLastname);
                       
            List<WriteModel<BsonDocument>> list_of_operations = new List<WriteModel<BsonDocument>>();
            ReplaceOneModel<BsonDocument> write_model = new ReplaceOneModel<BsonDocument>(filter, person.ToBsonDocument());
            write_model.IsUpsert = true;
            list_of_operations.Add(write_model);
            BulkWriteResult<BsonDocument> outcome = _collection.BulkWrite(list_of_operations, new BulkWriteOptions { IsOrdered = false });
            System.Console.WriteLine($"Processed {outcome.ProcessedRequests.Count} item(s)");
        }
