    files = files
		.Select(f => new { File = f, Name = Path.GetFileNameWithoutExtension(f.Name) })
		.Select(x => new
		{
			x.File,
			x.Name,
			Token = x.Name.Substring(x.Name.LastIndexOf("_", StringComparison.Ordinal) + 1)
		})
		.Select(x => new
		{
			x.File,
			x.Name,
			x.Token,
			IsInt = int.TryParse(x.Token, out int number),
			ParsedNumber = number
		})
		.OrderByDescending(x => x.IsInt)
		.ThenBy(x => x.ParsedNumber)
		.Select(x => x.File)
		.ToList();
