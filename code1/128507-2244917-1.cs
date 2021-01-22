    public IEnumerable<Post> ShowablePosts 
    {
        get 
        {
            return db.Posts.Where(WhereActive);
        }
    }
