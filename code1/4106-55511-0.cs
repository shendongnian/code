    public static class JSonify
    {
    	public static string GetJsonTable<T>(
    		this IQueryable<T> query, int pageNumber, int pageSize, string IDColumnName, string[] columnNames)
    	{
    		string select = string.Format("new ({0} as ID, \"CELLSTART\" as CELLSTART, {1}, \"CELLEND\" as CELLEND)", IDColumnName, string.Join(",", columnNames));
    		var items = new
    		{
    			page = pageNumber,
    			total = query.Count(),
    			rows = query.Select(select).Skip((pageNumber - 1) * pageSize).Take(pageSize)
    		};
    		string json = JavaScriptConvert.SerializeObject(items);
    		json = json.Replace("\"CELLSTART\":\"CELLSTART\",", "\"cell\":[");
    		json = json.Replace(",\"CELLEND\":\"CELLEND\"", "]");
    		foreach (string column in columnNames)
    		{
    			json = json.Replace("\"" + column + "\":", "");
    		}
    		return json;
    	}
    }  
