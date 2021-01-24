	public static class IServiceCollectionExtensions
	{
		public static IdentityBuilder AddCustomDefaultIdentity<TUser>(this IServiceCollection services, Action<IdentityOptions> configureOptions) where TUser : class
		{
			services.AddAuthentication(o =>
			{
				o.DefaultScheme = IdentityConstants.ApplicationScheme;
				o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
			})
			.AddIdentityCookies(o => { });
			return services.AddIdentityCore<TUser>(o =>
			{
				o.Stores.MaxLengthForKeys = 128;
				configureOptions?.Invoke(o);
			})
			.AddDefaultTokenProviders();
		}
	}
