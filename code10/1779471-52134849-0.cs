    public async Task<string> RetrieveDynamicCollection()
		{
			try
			{
				IMongoDatabase _db = client.GetDatabase("MyDB");
				var list = _db.GetCollection<HazopCollectionInfo>("AllCollectionInfo").AsQueryable().ToList();
				var collectionList = list.OrderBy(x => x.CollectionOrder).Select(x => x.CollectionName).Distinct().ToList();
				var listOfJoinDocuments = new List<BsonDocument>();
				var firstCollection = _db.GetCollection<BsonDocument>(collectionList[0]);
				var options = new AggregateOptions()
				{
					AllowDiskUse = false
				};
				var previousCollectionName = "";
				for (int i = 0; i < collectionList.Count; i++)
				{
					var collectionName = collectionList[i];
					IMongoCollection<BsonDocument> collection = _db.GetCollection<BsonDocument>(collectionName);
					if (i == 0)
					{
						firstCollection = collection;
						var firstarray = new BsonDocument("$project", new BsonDocument()
							.Add("_id", 0)
							.Add(collectionName, "$$ROOT"));
						listOfJoinDocuments.Add(firstarray);
					}
					else
					{
						var remainingArray = new BsonDocument("$lookup", new BsonDocument()
								.Add("localField", previousCollectionName + "." + "Id")
								.Add("from", collectionName)
								.Add("foreignField", "ParentId")
								.Add("as", collectionName));
						listOfJoinDocuments.Add(remainingArray);
						remainingArray = new BsonDocument("$unwind", new BsonDocument()
								.Add("path", "$" + collectionName)
								.Add("preserveNullAndEmptyArrays", new BsonBoolean(true)));
						listOfJoinDocuments.Add(remainingArray);
					}
					previousCollectionName = collectionName;
				}
				// Project the columns 
				list.OrderBy(x => x.ColumnOrder);
				var docProjection = new BsonDocument();
				for(int i=0;i<list.Count;i++)
				{
					docProjection.Add(list[i].ColumnName, "$"+list[i].CollectionName + "." + list[i].FieldName);
				}
				listOfJoinDocuments.Add(new BsonDocument("$project", docProjection));
				PipelineDefinition<BsonDocument, BsonDocument> pipeline = listOfJoinDocuments;
				var listOfDocs = new List<BsonDocument>();
				using (var cursor = await firstCollection.AggregateAsync(pipeline, options))
				{
					while (await cursor.MoveNextAsync())
					{
						var batch = cursor.Current;
						foreach (BsonDocument document in batch)
						{
							listOfDocs.Add(document);
						}
					}
				}
				var jsonString = listOfDocs.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { OutputMode = MongoDB.Bson.IO.JsonOutputMode.Strict });
				return jsonString;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
