    public partial class Startup
    {
        private IEmailSender _emailSender;
        public Startup()
        {
            _emailSender = DependencyResolver.Current.GetService<IEmailSender>();
        }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           _emailSender.SendEmail();
        }
    }
