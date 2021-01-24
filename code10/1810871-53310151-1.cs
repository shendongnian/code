    var commentCount = story.Comments.Count();
    // count all replies to all comments for a story
    var replyCountSum = story.Comments
        .SelectMany(c => c.Replies)
        .Count();
