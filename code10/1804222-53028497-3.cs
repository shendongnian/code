    using (var context = new TopicContext())
    {
      var topicsDO = context.Topics
        .Include(t=> t.Childrens)
        .Select(a => new
        {
            Id = a.BlogId,
            Title= a.Url,
            ChildrenIds = a.Children.Select(x => x.Id).ToArray()
        })
        .ToList();
    }
