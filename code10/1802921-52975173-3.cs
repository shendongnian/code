    if (signedInUserId == null)
    {
        var viewModel = new StoryDetailsViewModelAnonymousUser
        {
            StoryId = FoundStory.Id,
            AuthorId = FoundStory.AuthorId,
            Story = FoundStory,
            Comments = _dbContext.Comments.Where(x => x.StoryId == FoundStory.Id).ToList()
        };
        return View(viewModel);
    } else
    {
        var viewModel = new StoryDetailsViewModelSignedInUser
        {
            StoryId = FoundStory.Id,
            AuthorId = FoundStory.AuthorId,
            Story = FoundStory,
            User = _dbContext.Users.SingleOrDefault(x => x.Id == signedInUserId),
            Comments = _dbContext.Comments.Where(x => x.StoryId == FoundStory.Id).ToList()
        };
        return View(viewModel);
    }
