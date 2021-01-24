	public static IdentityBuilder AddDefaultIdentity<TUser>(this IServiceCollection services, Action<IdentityOptions> configureOptions) where TUser : class
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
		.AddDefaultUI() // It'll be removed
		.AddDefaultTokenProviders();
	}
