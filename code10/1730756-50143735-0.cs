             var challengesQ = ( from ch in challengeContext.Challenges
                          join cc in challengeContext.ChallengeCategories
                          on ch.Category equals cc.Id 
                          select new Category  {
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
                          }
                           );
