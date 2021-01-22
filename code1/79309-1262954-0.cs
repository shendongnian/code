    var postTimes = (from post in db.Post
                    where post.LastActivityUtc != null
                    orderby post.LastActivityUtc descending
                    select post.LastActivityUtc).Take(100).ToList();
    DateTime startDate = DateTime.MinValue;
    if (postTimes.Count >= 2)
    {
        startDate = postTimes.Last().Value;
    }
