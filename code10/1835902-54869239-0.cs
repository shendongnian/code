`
//Sharded collection must be initialized this way
var bson = new BsonDocument
{
    { "shardCollection", mongoClientProvider.DatabaseName + "." + CollectionName },
    { "key", new BsonDocument(ShardKeyName, "hashed") }
};
var shellCommand = new BsonDocumentCommand<BsonDocument>(bson);
try
{
    var commandResult = database.RunCommand(shellCommand);
}
catch (MongoCommandException ex)
{
    logger.LogError(ex, ex.Result.ToString());
}
`
