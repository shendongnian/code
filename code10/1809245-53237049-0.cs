	var category =
		productList
			.GroupBy(g => g.Category)
			.Select(s => new
			{
				Category = s.Key,
				Units = s.Select(s2 => new { s2.UnitsInStock, s2.UnitPrice })
			});
	foreach (var categ in category)
	{
		Console.WriteLine($"Category: {categ.Category}");
		foreach (var unit in categ.Units)
		{
			Console.WriteLine($"UnitsInStock: {unit.UnitsInStock}; UnitPrice: {unit.UnitPrice}");
		}
	}
