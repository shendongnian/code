    public static class Extensions
    {
    	public static IEnumerable<T> MyOrderBy<T>(
    		this IEnumerable<T> source, 
    		params Func<T, object>[] orders)
    	{
    		Debug.Assert(orders.Length > 0);
    		var sortQuery = source.OrderBy(orders[0]);
    		foreach(var order in orders.Skip(1))
    		{
    			sortQuery = sortQuery.ThenBy(order);
    		}
    		return sortQuery;
    	}
    }
    public class Poco
    {
    	public string Name {get; set;}
    	public int Number {get; set;}
    }
    void Main()
    {
    	var items = new []{
    		new Poco{Name = "Zebra", Number = 99}, 
    		new Poco{Name = "Apple", Number = 123}};
    		
    	foreach(var poco in items.MyOrderBy(i => i.Number, i => i.Name))
    	{
    		Console.WriteLine(poco.Name);
    	}
    }
