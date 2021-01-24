    public class MessageService
    {
        IServiceProvider _serviceProvider;
        public MessageService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    
        public void Send()
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            using (Context ctx = scope.ServiceProvider.GetRequiredService<Context>())
            {
                var emails = ctx.Users.Select(x => x.Email).ToList();
    
                foreach (var email in emails)
                {
                    sendEmail(email, "sample body");
                }
            }
        }
    }
