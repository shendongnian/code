        services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
            options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
            options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
        }).AddDefaultTokenProviders()
        .AddEntityFrameworkStores<YourDbContext>();
