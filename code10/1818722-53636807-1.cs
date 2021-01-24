	var json = JsonConvert.SerializeObject(new
	{
		People = persons.Select((x, i) => new
		{
			PersonId = (i + 1).ToString(),
			PersonFields = flattenedProperties.Select(p => new { Description = p.Property.Name, Value = p.Property.GetValue(p.Parent == null ? x : p.Parent.GetValue(x)) })
		})
	});
