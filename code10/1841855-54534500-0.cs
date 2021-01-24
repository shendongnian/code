        public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser<int>>
        {
            public CustomClaimsPrincipalFactory(UserManager<IdentityUser<int>> userManager,
                                                    IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
            {
            }
            public async override Task<ClaimsPrincipal> CreateAsync(IdentityUser<int> user)
            {
                var principal = await base.CreateAsync(user);
                // Add your claims here
                ((ClaimsIdentity)principal.Identity).AddClaims(
                    new[] { new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(CustomClaimTypes.UserId, user.Id.ToString())
                    });
                return principal;
            }
        }
