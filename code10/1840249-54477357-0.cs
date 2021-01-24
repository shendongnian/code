			var result = elasticClient.UpdateByQuery<ProductType>(u => u
				.Index("product")
				.Script(ss => ss.Source("for(int i=0; i<ctx._source.productAttributes.size(); i++){HashMap myKV = ctx._source.productAttributes.get(i);myKV.put(params.item.fieldName, params.item.fieldValue);}")
							.Params(d => d.Add("item", new Dictionary<string, object>()
							{
								{"fieldName", "name" },
								{"fieldValue", "new name" }
							})).Lang("painless")));
 
