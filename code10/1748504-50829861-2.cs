    public static class DateRestrictedExtensions
    {
        public static Expression<Func<IDateRestricted, bool>> IsActive()
        {
            return entity => entity.StartDate <= DateTime.Now 
                             && (entity.EndDate == null || entity.EndDate > DateTime.Now);
        }
    }
    
    var admins = users.Where(x => x.Roles.Where(role.Type == RoleType.Admin).Any(IsActive()));
