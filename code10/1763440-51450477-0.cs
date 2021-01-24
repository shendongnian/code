	foreach (var entityType in r.EdmxEdmx.EntityType)
	{
		foreach (var property in entityType.Property)
		{
			Console.WriteLine("-Name: " + property.Name);
			Console.WriteLine("-Type: " + property.Type);
			Console.WriteLine();
		}
	}
