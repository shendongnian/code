    var oldUsersWithManyReactions = myDbContext.Users
        .Where(user => user.BirthDay < new DateTime(2040, 1, 1))
        .Select(user => new 
        {
            // Select only the user properties you plan to use
            Id = user.Id,
            FullName = user.Name.First + User.Name.Last,
            // select the Posts of this User:
            RecentPosts = user.Posts
                .Where(post.PublicationDate > DateTime.UtcNow.AddDay(-7))
                .Select(post => new
                {
                    // again select only the Properties you want to use:
                    Title = post.Title,
                    PublicationDate = post.PublicationDate,
                    ReactionCount = post.Reactions.Count(),
                }),
            }),
        }),
    });
