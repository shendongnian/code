    public void setPost(Post post)
    {
        if (post instanceof Question)
        {
            _question = (Question)post;
        }
    }
