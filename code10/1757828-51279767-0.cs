        var resultBsons = await _collection.Find<BsonDocument>(jsonSearch)
            .Project(Builders<BsonDocument>.Projection
                                                .Exclude("_id"))
                                                .ToListAsync();
        JObject json = JObject.Parse(resultBsons[0].ToJson());
        JArray MenuCard = (JArray)json["MenuCard"];
        var SubCat = MenuCard.Values("Subcategory").ToArray();
        int nReturn = -1;
        for (int i = 0; i <= SubCat.Count(); i++)
        {
            if ((string)SubCat[0][i]["Title"] == "Wine")
            {
                nReturn = i;
                break;
            }
        }
        string insertString = "MenuCard.0.Subcategory."+nReturn.ToString()+".SubcategoryItems";
