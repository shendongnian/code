    public void UpdateParentIdForChildren(string oldParentId, string newParentId, int collectionIndex)
    		{
    
    		
    			if (collectionIndex > collectionList.Count)
    			{
    				return;
    			}
    
    			
    			var currentCollection = _db.GetCollection<dynamic>(collectionName);
    			var filter = Builders<dynamic>.Filter.Eq("ParentId", oldParentId);
    			var oldParentIdList = currentCollection.Find(filter).ToList();
    			var reoldParentIdList = oldParentIdList.OrderByDescending(x => ((IDictionary<string, object>)x)["Index"]).ToList();
    			if (reoldParentIdList.Count > 0)
    			{
    				for (int i = 0; i < reoldParentIdList.Count; i++)
    				{
    					var remainingRecord = reoldParentIdList[i] as IDictionary<string, object>;
    
    					Object OldIdValue = "";
    					remainingRecord.TryGetValue("Id", out OldIdValue);
    
    					Object indexValue = "";
    					remainingRecord.TryGetValue("Index", out indexValue);
    
    					var newId = newParentId + '.' + indexValue;
    
    					currentCollection.UpdateOne(filter, Builders<dynamic>.Update.Set("Id", newId));
    					currentCollection.UpdateOne(filter, Builders<dynamic>.Update.Set("ParentId", newParentId));
    
    					UpdateParentIdForChildren(OldIdValue.ToString(), newId, collectionIndex + 1);
    				}
    			}
    		}
