    var viewModel = new StoryDetailsViewModelAnonymousUser
    {
        StoryId = FoundStory.Id,
        AuthorId = FoundStory.AuthorId,
        Story = FoundStory,
        Comments = _dbContext.Comments.Where(x => x.StoryId == FoundStory.Id).ToList()
    };
    if (signedInUserId != null)
    {
        viewModel.User = _dbContext.Users.SingleOrDefault(x => x.Id == signedInUserId);
    }
    
    return View(viewModel);
