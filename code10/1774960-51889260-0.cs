    public class Startup
    {
        public void ConfigureServices(ServiceCollection services)
        {
            // Here you'd have your registrations
            services.AddTransient<IClaimsTransformation, ClaimsTramsformer>();
        }
    }
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly ApplicationDbContext _context;
        public ClaimsTramsformer(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var existingClaimsIdentity = (ClaimsIdentity)principal.Identity;
            var currentUserName = existingClaimsIdentity.Name;
            // Initialize a new list of claims for the new identity
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, currentUserName),
                // Potentially add more from the existing claims here
            };
            // Find the user in the DB
            // Add as many role claims as they have roles in the DB
            IdentityUser user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(currentUser, StringComparison.CurrentCultureIgnoreCase));
            if (user != null)
            {
                var rolesNames = from ur in _context.UserRoles.Where(p => p.UserId == user.Id)
                            from r in _context.Roles
                            where ur.RoleId == r.Id
                            select r.Name;
                claims.AddRange(rolesNames.Select(x => new Claim(ClaimTypes.Role, x)));
            }
            // Build and return the new principal
            var newClaimsIdentity = new ClaimsIdentity(claims, existingClaimsIdentity.AuthenticationType);
            return new ClaimsPrincipal(newClaimsIdentity);
        }
    }
