    foreach(var comment in comments)
    {
        if (comment.AuthorId == user.Id)
        {
            comment.IsCommenter = true;
        }
        else 
        {
            comment.IsCommenter = false;
        }
    }
