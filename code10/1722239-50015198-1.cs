        var connectionString = "mongodb://localhost";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("extend");
        var collection = database.GetCollection<Entity>("user");
        
        
        var entity_TargetUser = collection.AsQueryable().where(e=>e.user_id == 
        int.Parse(targetUser.CurrentUser)).single();
