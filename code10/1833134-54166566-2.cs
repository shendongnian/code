	var questions = data.GroupBy(x => new {x.QestionId, x.Title, x.Description}).Select(y => new Question
	{
		Id = y.Key.QestionId,
		Title = y.Key.Title,
		Description = y.Key.Description,
		Tags = y.Select(z => new Tag
		{
			Id = z.TagId,
			Name = z.Name
		})
	}).ToList();
