    static void Main(string[] args)
    {
    	NorthwindDataContext db = new NorthwindDataContext();
    	var query = db.Customers;
    	string json = query.GetJsonTable<Customer>(2, 10, "CustomerID", new string[] {"CustomerID", "CompanyName", "City", "Country", "Orders.Count" });
     }  
    public static class JSonify
    {
    	public static string GetJsonTable<T>(
    		this IQueryable<T> query, int pageNumber, int pageSize, string IDColumnName, string[] columnNames)
    	{
    		string select = string.Format("new ({0} as ID, new ({1}) as cell)", IDColumnName, string.Join(",",     columnNames));
    		var items = new
    		{
    			page = pageNumber,
    			total = query.Count(),
    			rows = query.Select(select).Skip((pageNumber - 1) * pageSize).Take(pageSize)
    		};
    		return JavaScriptConvert.SerializeObject(items);
    	}
    }  
