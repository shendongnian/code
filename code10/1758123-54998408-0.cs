	public static class IdentityExtensions {
		public static IServiceCollection AddApplicationIdentity(
			this IServiceCollection services) {
			services.AddAuthentication(
				o => {
					o.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
					o.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
					o.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
				}).AddCookie(IdentityConstants.ApplicationScheme,
				o => {
					o.Cookie.Expiration = TimeSpan.FromHours(8);
					o.Cookie.SameSite = SameSiteMode.Strict;
					o.Cookie.SecurePolicy = CookieSecurePolicy.Always;
					o.AccessDeniedPath = new PathString("/");
					o.ExpireTimeSpan = TimeSpan.FromHours(8);
					o.LoginPath = new PathString("/sign-in");
					o.LogoutPath = new PathString("/sign-out");
					o.SlidingExpiration = true;
				});
			services.AddIdentityCore<User>(
						o => {
							o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
							o.Lockout.MaxFailedAccessAttempts = 5;
							o.Password.RequiredLength = 8;
						})
					.AddSignInManager<ApplicationSignInManager>()
					.AddUserStore<ApplicationUserStore>();
			services.Configure<SecurityStampValidatorOptions>(
				o => {
					o.ValidationInterval = TimeSpan.FromMinutes(1);
				});
			return services;
		}
	}
