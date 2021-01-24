    Expression<Func<Post, bool>> lastPostsQuery = post => false;
    foreach (var topic in topics) 
    {
        lastPostsQuery = lastPostsQuery.Or(post => post.TopicId == topic.TopicId && post.CreatedDate = topic.CreatedDate); //.Or is implemented in PredicateBuilder
    }
    var lastPosts = _context.Posts.Where(lastPostsQuery).ToList();
