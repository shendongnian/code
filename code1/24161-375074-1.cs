    public static class UserQueryableExtensions
    {
        public static IOrderedQueryable<User> OrderBy(this IQueryable<User> source,
                                                      string ordering)
        {
            switch (ordering)
            {
                case "LastName":
                    return source.OrderBy(x => x.LastName);
                case "FirstName":
                    return source.OrderBy(x => x.FirstName);
                case "Email":
                    return source.OrderBy(x => x.Email);
                case "Company":
                    return source.OrderBy(x => x.Company);
                default:
                    throw new ArgumentException("Unknown ordering");
            }
        }
    }
