    using (var dbContext = new MyDbContext())
    {
        var result = dbContext.Questions      // take your table Questions
            .Select(question => new           // for every question in this table, make one new object
            {
                 Id = question.Id,
                 Text = question.QuestionText,
                 UpvoteCount = question.Upvotes.Count,
            });
    }
