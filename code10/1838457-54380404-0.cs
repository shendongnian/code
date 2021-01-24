void Main()
{
	var threeItems = new List<DateTimeOffset>(new[] { DateTimeOffset.Now, DateTimeOffset.Now.AddDays(-1), DateTimeOffset.Now.AddDays(-2) });
	var twoItems = new List<DateTimeOffset>(new[] { DateTimeOffset.Now, DateTimeOffset.Now.AddDays(-1) });
	var oneItem = new List<DateTimeOffset>(new[] { DateTimeOffset.Now });
	ShowItems(GetItems(threeItems));
	ShowItems(GetItems(twoItems));
	ShowItems(GetItems(oneItem));
}
IEnumerable<DateTimeOffset> GetItems(List<DateTimeOffset> items)
{
	return items
		.OrderByDescending(i => i)
		.Select(i => i)
		.Take(2);
}
void ShowItems(IEnumerable<DateTimeOffset> items)
{
	Console.WriteLine("List of Items:");
	
	foreach (var item in items)
	{
		Console.WriteLine(item);
	}
}
