    var client = new MongoClient(DBString);
    var database = client.GetDatabase("UserLists");
    var collection = database.GetCollection<UserObject>(Convert.ToString(GuildId));
    
    var filter = Builders<UserObject>.Filter.Eq(s => s.Username, newUserName);
    
    var UpdatedUserObject = new UserObject
    {
        UserID = UserId,
        Username = newUserName,
        CharClass = newCharClass,
        CharLevel = newCharLevel,
        CharColour = newCharColour 
    };
    
    collection.ReplaceOne(filter, UpdatedUserObject);
