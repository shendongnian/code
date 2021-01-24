    var allTags = myDbContext.Tags
        .Select(tag => new DisplayableTag()
        {
            TagId = tag.Id,
            Display = tag.Text,
        })
        .OrderBy(tag => tag.Text)    // an ordered drop down look nicer
        .ToList();
