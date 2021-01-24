    private Dictionary<string, float> CreateResult(Dictionary<string, object> items)
    		{
    			var result = new Dictionary<string, float>();
    			foreach (var item in items)
    			{
    				result.Add(item.Key, (float)item.Value);
    			}
    			return result;
    		}
