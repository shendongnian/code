            var builder = Builders<newMsg>.Filter;
            var filter = builder.Eq("Type", "CREATE") & builder.Eq("Entities.ErrorCondition", 14) & builder.Eq("MsgRead", false);
            var result = collection.Find(filter).ToList();
            if (result.Count > 0)
            {
                //Create a list of distinct msgs, then set msgRead to True, then pass that list to a new filter  
                var distinctMsg = collection.Distinct(new StringFieldDefinition<newMsg, string>("Entities.ID"), FilterDefinition<newMsg>.Empty).ToList();
                foreach (var dm in distinctMsg)
                {
                    var entityID = dm;
                    var msgUnread = Builders<newMsg>.Filter.Eq("msgRead", false);
                    var msgUpdate = Builders<newMsg>.Update.Set("msgRead", true);
                    var msgIsRead = collection.UpdateOne(msgUnread, msgUpdate);
                    //Create another filter on the distinct messages
                    CreateDistinctFilter(mongoClient, db, collection, entityID, ec);
                }
                using (IAsyncCursor<newMsg> cursor = await collection.FindAsync(filter))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        IEnumerable<newMsg> batch = cursor.Current;
                        foreach (newMsg document in batch)
                        {
                            //This gives me the entire list as a string
                            var subDocument = document.Entities;
                            foreach (var sd in subDocument)
                            {
                             //log duplicate msg
                            }
                        }
                    }
                }
            }
       static async void CreateDistinctFilter(MongoClient mongoClient, IMongoDatabase db, IMongoCollection<newMsg> collection, string entityID, string ec)
        {
            var builder = Builders<newMsg>.Filter;
            var distinctFilter = builder.Eq("Entities.ID", entityID) & builder.Eq("MsgRead", true);
            var result = collection.Find(distinctFilter).ToList();
            using (IAsyncCursor<newMsg> cursor = await collection.FindAsync(distinctFilter))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<newMsg> batch = cursor.Current;
                    foreach (newMsg document in batch)
                    {
                        //This gives me the entire list as a string
                        var subDocument = document.Entities;
                        foreach (var sd in subDocument)
                        {
                            string DeviceName = sd.Name;
                            string Title = DeviceName + " Device DOWN";
                            string Msg = sd.Reason + sd.ID;
                            string ErrorCondition = ec;
                            Console.WriteLine("UNIQUE: " + " " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff") + Msg );
                            Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
