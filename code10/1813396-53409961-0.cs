	string lowerCasePartOfName = partOfName.ToLower();
	var categories = await _context.ECATEGORIES
        .Where(a => a.NAME.ToLower().Contains(lowerCasePartOfName))
		.GroupJoin(_context.ECATEGORIES, child => child.ParentId, parent => parent.ID, (child, parent) => new {Category, ParentName = parent.Name})
		.Select(_ => new Category{
			CategoryParent = _.ParentName,
			Id = _.Category.Id,
			// etc
		})
		.ToListAsync(ct);
