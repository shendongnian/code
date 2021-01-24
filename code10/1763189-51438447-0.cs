     public class CIAuthoringManagement : AuthorizationHandler<CIAuthoringManagementRequirement, ConfigurationItem>
    {
        private readonly MyAppContext _context;
        public CIAuthoringManagement(MyAppContext context)
        {
            _context = context;
        }
        [DebuggerStepThrough]
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CIAuthoringManagementRequirement requirement, ConfigurationItem resource)
        {
            var user = _context.Users.Include(u => u.Groups).Include(u => u.Employer).Include(c => c.AuthoringCatalogs).AsNoTracking().SingleOrDefault(m => m.ID == context.User.GetUniqueIdentifier());
            if (user != null)
            {
                //Allowing SuperAdmins by default
                var group = _context.Groups.Include(g => g.Users).ThenInclude(g => g.User).AsNoTracking().SingleOrDefault(g => g.DisplayName == "SuperAdmins");
                if (group != null)
                {
                    var groupUsers = new HashSet<Guid>(group.Users.Select(u => u.User.ID));
                    if (groupUsers.Contains(user.ID))
                    {
                        context.Succeed(requirement);
                    }
                }
                //Allowing CI if it's part of the catalogs where CI is author
                //hashset of id where user is declared author
                var authorCatalogHS = new HashSet<Guid>(user.AuthoringCatalogs.Select(c => c.CatalogId));
                if (resource.Catalogs != null)
                {
                    foreach (var catalog in resource.Catalogs)
                    {
                        if (authorCatalogHS.Contains(catalog.CatalogId))
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
                else
                    context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
