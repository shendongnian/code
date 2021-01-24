	var characteristics = person.GetType().GetProperty("Characteristic", BindingFlags.Instance | BindingFlags.Public).GetValue(person, null) as System.Array;
	foreach (var c in characteristics.Cast<Characteristic>())
	{
		Console.WriteLine("{0} = {1}", c.Name, c.Value);
	}
