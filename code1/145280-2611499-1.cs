    //Returns a list of the latest feeds, restricted by the count.
    public IList<PostFeed> GetPostFeeds(int latestCount)
    {
       var posts = repository.GetPosts();
       // Perform additional filtering here e.g:
       posts = posts.Take(5);
       return posts.ToList();
    }
