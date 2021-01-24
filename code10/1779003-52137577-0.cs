                    dynamic expando = new ExpandoObject();
					var collectionModel = expando as IDictionary<string, Object>;
					
					var lastDotPosition = value.LastIndexOf('.');
					var parentId = value.Substring(0, lastDotPosition);
					collectionModel.Add("ParentId", parentId);
					var order = Convert.ToInt32(value.Split('.').Last());
				
					var newOrder = order + 1;
					var Id = parentId + '.' + newOrder.ToString();
					collectionModel.Add("Index", newOrder);//newOrder
					collectionModel["Id"] = Id;
					var filter = Builders<dynamic>.Filter.Gt("Index", order);
					filter = filter & Builders<dynamic>.Filter.Eq("ParentId", parentId);
					var collection = _db.GetCollection<dynamic>(collectionName);
					var remainingList = collection.Find(filter).ToList();
					var dynamicList = new List<ExpandoObject>();
					dynamicList.Add((ExpandoObject)collectionModel);
                    // below updates the next record ids and parent id to ensure numbering is maintained
					for (int i = 0; i < remainingList.Count; i++)
					{
						var remainingRecord = remainingList[i] as IDictionary<string, object>;
						var newRecord = new ExpandoObject() as IDictionary<string, Object>;
						for(int j = 0; j < listOfFieldNames.Count; j++)
						{
							var fieldName = listOfFieldNames[j];
							Object dictValue = "";
							remainingRecord.TryGetValue(fieldName, out dictValue);
							if (fieldName == "Id")
							{
								newRecord[fieldName] = parentId + "." + (newOrder + 1);
							}
							else
							{
								newRecord[fieldName] = dictValue;
							}
						}
						newRecord["Index"] = newOrder + 1;
						newRecord["ParentId"] = parentId;
						newOrder++;
						dynamicList.Add((ExpandoObject)newRecord);
					}
					
					//Now update child or grandchild if any
					var updateForChildList = remainingList.OrderByDescending(x => ((IDictionary<string, object>)x)["Index"]).ToList();
					for (int k = 0; k < updateForChildList.Count; k++)
					{
						var oldRecord = updateForChildList[k] as IDictionary<string, object>;
						var oldParentId = oldRecord["Id"];
						Object dictValue = "";
						oldRecord.TryGetValue("Index", out dictValue);
						
						var newParentId = oldRecord["ParentId"] + "." + Convert.ToString(Convert.ToInt32(dictValue.ToString()) + 1);
						UpdateParentIdForChildren(oldParentId.ToString(), newParentId, Convert.ToInt32(collectionOrder + 1));
					}
					collection.DeleteMany(filter);
					collection.InsertMany(dynamicList);
