    stories.Select(s => new
    {
        Story = s,
        CommentCount = s.Comments.Count(),
        ReplyCount = s.Comments.SelectMany(c => c.Replies).Count(),
    });
