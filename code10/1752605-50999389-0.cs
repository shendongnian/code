    var taggable = Expression.Parameter(typeof(Taggable), "taggable");
    var tag = Expression.Parameter(typeof(Tag), "tag");
    var searchTag = Expression.Parameter(typeof(long), "searchTag");
    // tag.TagId == searchTag
    var anyCondition = Expression.Equal(
    	Expression.Property(tag, "TagId"),
    	searchTag);
    // taggable.Tags.Any(tag => tag.TagId == searchTag)
    var anyCall = Expression.Call(
    	typeof(Enumerable), nameof(Enumerable.Any), new[] { typeof(Tag) },
    	Expression.Property(taggable, "Tags"), Expression.Lambda(anyCondition, tag));
    // searchTags.All(searchTag => taggable.Tags.Any(tag => tag.TagId == searchTag))
    var allCall = Expression.Call(
    	typeof(Enumerable), nameof(Enumerable.All), new[] { typeof(long) },
    	Expression.Constant(searchTags), Expression.Lambda(anyCall, searchTag));
    // taggable => searchTags.All(searchTag => taggable.Tags.Any(tag => tag.TagId == searchTag))
    var lambda = Expression.Lambda(allCall, taggable);
