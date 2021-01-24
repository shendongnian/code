    namespace gtbweb.Areas.Identity.Pages.Account
    {
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IEmailSender _emailSender;
        private readonly AboutDbContext _theContext;
        public RegisterModel(
            IEmailSender emailSender,
            AboutDbContext theContext)
        {
            
            _emailSender = emailSender;
            _theContext = theContext;
        }
       public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
              
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });          
                    services.AddDbContext<AboutDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.BuildServiceProvider()
            .GetService<Areas.Identity.Pages.Account.RegisterModel>();
        }
