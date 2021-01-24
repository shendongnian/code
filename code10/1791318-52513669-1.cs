			var collection = database.GetCollection<VehicleModel>("VehicleModel");
	
	        var Data = await collection.Find(Builders<VehicleModel>.Filter.Empty).ToListAsync();
			
			foreach(VehicleModel vm in Data)
			{
				var newDoc =
				{
				"key": "value",
				"doc": vm
				collection.InsertOneAsync(value);
				}
			}
			
