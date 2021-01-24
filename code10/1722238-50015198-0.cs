        var connectionString = "mongodb://localhost";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("extend");
        var collection = database.GetCollection<Entity>("user");
        var query = Query<Entity>.EQ(e.user_id,int.Parse(targetUser.CurrentUser));
        
        var entity_TargetUser = collection.AsQueryable().where(query).single();
