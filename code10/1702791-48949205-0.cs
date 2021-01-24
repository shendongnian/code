    public class EmailSettings
    {
        public string AdminEmail { get; set; } // encapsulate as needed
    }
    public void ConfigureServices(IServiceCollection services)
    {
        var settings = new EmailSettings
        {
            AdminEmail = Configuration["AdminEmail"]
        };
        services.AddSingleton(settings);
    }
    public class WhereverYouNeedThis
    {
        private readonly EmailSettings _emailSettings;
        public WhereverYouNeedThis(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public void Use()
        {
            Debug.Log(_emailSettings.AdminEmail);
        }
    }
