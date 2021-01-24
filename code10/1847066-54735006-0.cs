    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services">Services to include</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
        // Add Decompression options
        var decompressOptions = new RequestDecompressionOptions();
        decompressOptions.UseDefaults();
        decompressOptions.AddProvider<GzipDecompressionProvider>();
        decompressOptions.SkipUnsupportedEncodings = false;
        services.AddRequestDecompression(decompressOptions);
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        var connection = Configuration.GetConnectionString("MySiteUsers");
        var mailingListConnection = Configuration.GetConnectionString("MailingList");
        services.AddDbContext<MySiteContext>(options => options.UseSqlServer(connection));
        services.AddDbContext<MySiteMailingListContext>(options => options.UseSqlServer(mailingListConnection));
    }
