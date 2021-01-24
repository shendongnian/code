      protected async void ddlcategorie_SelectedIndexChanged(object sender, EventArgs e)
    {
        IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("tarifs");
        
        BsonDocument filter = new BsonDocument();
        BsonDocument projection = new BsonDocument();
        projection.Add("Categorie", 1);
        projection.Add("SousCategorie.ValeurMin", 1);
        projection.Add("SousCategorie.SousCategorieLibelle", 1);
        var options = new FindOptions<BsonDocument>()
        {
            Projection = projection
        };
        using (var cursor = await collection.FindAsync(filter, options))
        {
            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (BsonDocument document in batch)
                {
                    Console.WriteLine(document.ToJson());
                }
            }
        }
    }
