    static class MyDbContextExtensions
    {
        // returns ne ApplicationUserExt for every ApplicationUser
        public IQueryable<ApplicationUserExt> ToExtendedUsers(this IQueryable<ApplicationUser> applicationUsers)
        {
            return applicationUsers
                .Select(user => new ApplicationUserExt()
                {
                   Id = user.Id,
                   FirstName = user.FirstName,
                   LastName = user.LastName,
                   LatestTransaction = user.Trnasactions
                       .OrderByDescenting(transaction => transaction.CreationDate)
                        .FirstOrDefault(),
                }
            }
        }
    }
