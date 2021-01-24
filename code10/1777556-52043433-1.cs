    // Define our aggregation steps.
    // Step 1, $project:
    var project = new BsonDocument
    { {
        "$project", new BsonDocument
        {
            {
                "_id", 0
            },
            {
                "fields", new BsonDocument
                { {
                    "$map", new BsonDocument
                    {
                        { "input", new BsonDocument { { "$objectToArray", "$$ROOT" } } },
                        { "in", new BsonDocument {
                            { "fieldName", "$$this.k" },
                            { "fieldType", new BsonDocument { { "$type", "$$this.v" } } }
                        } }
                    }
                } }
            }
        }
    } };
    // Step 2, $unwind
    var unwind = new BsonDocument
    { {
        "$unwind", "$fields"
    } };
    // Step 3, $group
    var group = new BsonDocument
    {
        {
            "$group", new BsonDocument
            {
                {
                    "_id", new BsonDocument
                    {
                        { "fieldName", "$fields.fieldName" },
                        { "fieldType", "$fields.fieldType" }
                    }
                }
            }
        }
    };
    // Connect to our database
    var client = new MongoClient("myConnectionString");
    var db = client.GetDatabase("myDatabase");
    var collections = db.ListCollections().ToEnumerable();
    /*
    We will store the results in a dictionary of collections.
    Since the same field can have multiple types associated with it the inner value corresponding to each field is `List<string>`.
    The outer dictionary keys are collection names. The inner dictionary keys are field names.
    The inner dictionary values are the types for the provided inner dictionary's key (field name).
    List<string> fieldTypes = allCollectionFieldTypes[collectionName][fieldName]
    */
    Dictionary<string, Dictionary<string, List<string>>> allCollectionFieldTypes = new Dictionary<string, Dictionary<string, List<string>>>();
    foreach (var collInfo in collections)
    {
        var collName = collInfo["name"].AsString;
        var coll = db.GetCollection<BsonDocument>(collName);
        Console.WriteLine("Finding field information for " + collName);                
        var pipeline = PipelineDefinition<BsonDocument, BsonDocument>.Create(project, unwind, group);
        var cursor = coll.Aggregate(pipeline);
        var lst = cursor.ToList();
        allCollectionFieldTypes.Add(collName, new Dictionary<string, List<string>>());
        foreach (var item in lst)
        {
            var innerDict = allCollectionFieldTypes[collName];
            var fieldName = item["_id"]["fieldName"].AsString;
            var fieldType = item["_id"]["fieldType"].AsString;
            if (!innerDict.ContainsKey(fieldName))
            {
                innerDict.Add(fieldName, new List<string>());
            }
            innerDict[fieldName].Add(fieldType);
        }
    }
