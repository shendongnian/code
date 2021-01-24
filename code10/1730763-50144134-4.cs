    public IQueryable<Challenges> GetChallenges()
    {
        DbSet<Challenges> challenges = challengeContext.Challenges;
        DbSet<ChallengeCategories> categories = challengeContext.ChallengeCategories;
        return challenges.Join(
            categories,
            ch => ch.Category,
            cc => cc.Id,
            (ch, cc) => new Challenges()
            {
                id = ch.Id,
                title = ch.Title,
                createdAt = ch.CreatedAt,
                daysNeeded = ch.DaysNeeded,
                reward = ch.Reward,
                difficulty = ch.Difficulty,
                completedBy = ch.CompletedBy,
                imgUrl = ch.ImgUrl,
                subcategory = cc.Title,
                category = cc.Title,
                instructions = ch.Instructions
            });
        
    }
