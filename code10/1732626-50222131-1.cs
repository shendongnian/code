	var characteristics = person.GetType().GetProperty("Characteristic", BindingFlags.Instance | BindingFlags.Public).GetValue(person, null) as System.Array;
	foreach (var o in characteristics)
	{
		var name = o.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance).GetValue(o, null);
		var val  = o.GetType().GetProperty("Value", BindingFlags.Public | BindingFlags.Instance).GetValue(o, null);
		Console.WriteLine("{0} = {1}", name, val);
	}
