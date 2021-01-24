                   public class CustomUserStore : UserStore<IdentityUser>
        {
            public CustomUserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
            {
            }
            public override async Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken = default(CancellationToken))
            {
                var roleNames = await base.GetRolesAsync(user, cancellationToken);
                var roleIds = await Context.Set<IdentityRole>()
                                     .Where(r => roleNames.Contains(r.Name))
                                     .Select(r => r.Id)
                                     .ToListAsync();
                return roleIds;
            }
        }
