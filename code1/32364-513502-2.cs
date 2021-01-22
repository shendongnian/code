    private static Post GetPost(Guid id)
    {
        Post p = default(Post);
    
        foreach (Post post in _Posts)
        {
            if (post.Id == id)
            {
                p = post;
                break;
            }
        }
    
        return p;
    }
