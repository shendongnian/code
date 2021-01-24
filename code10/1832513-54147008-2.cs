    private List<KeyValuePair<int, Dictionary<string, float>>> CreateResult(List<Dictionary<string, object>> items)
		{
			var result = new List<KeyValuePair<int, Dictionary<string, float>>>();
			for (int i = 0; i < items.Count; i++)
			{
				var currentDic = new Dictionary<string, float>();
				var item = items[i];
				foreach (var itm in item)
				{
					currentDic.Add(itm.Key, (float)itm.Value);
				}
				result.Add(new KeyValuePair<int, Dictionary<string, float>>(i, currentDic));
			}
			return result;
		}
