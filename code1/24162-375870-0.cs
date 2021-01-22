    var unordered = ctx.ActiveUsers
                       .Where(Employee.GetExpression(searchString))
                       .MyOrder()
                       .Select(u => new Employee {
                           ID = u.ID,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Email = u.Email,
                           CompanyName = u.Company.Name,
                           CompanyID = u.CompanyID.ToString() });
----------
    public static class UserQueryableExtensions
    {
        public static IOrderedQueryable<User> MyOrder(this IQueryable<User> source )
        { 
            return source.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ThenBy(x => x.Email);
        }
    }
