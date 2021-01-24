    var stories = dbContext.Stories
        .Include("Genre")
        .Include("StoryType")
        .Include("StoryAgeRange")
        .Include("Visibility")
        .Where(x => x.AuthorId == foundUser.Id);
    // filter for public stories only when the author is not the current user
    if (!isRegisteredUser)
    {
        stories = stories.Where(x => x.Visibility.Name == "Public");
    }
