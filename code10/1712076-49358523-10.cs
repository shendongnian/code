    var usersWithAllTheirReactions = myDbContext.Users
        .Where (user => ...)
        .Select(user => new
        {
            Id = user.Id,
            Name = ...,
            AllReactions = user.Posts
                .SelectMany(post => post.Reactions)
                .Where(reaction => ...)
                .Select(reaction => new
                {
                    ReactionDate = reaction.Date,
                    Text = reaction.Text,
                }),
            }),
        });
