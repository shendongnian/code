    public class CustomMailConfigProvider: ConfigurationProvider
    {
        public CustomMailConfigProvider(Action<DbContextOptionsBuilder> dbOptions)
        {
            DbOptions = dbOptions;
        }
        Action<DbContextOptionsBuilder> DbOptions { get; }
        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ConfigurationContext>();
            DbOptions(builder);
            using (var dbContext = new ConfigurationContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();
                //Modify this to suit your needs, here is an example assuming you have a table called AuthMessageSenderOption with the same fields as the class in your question
                var authMessageSender = db.Context.AuthMessageSenders.FirstOrDefault();
                // You should add some code here to check if the settings exist and provide defaults if necessary
                Data = new Dictionary<string, string>
                {
                    { "PortNumber", authMessageSenderOption.PortNumber},
                    { "SmtpServer", authMessageSenderOption.SmtpServer },
                    { "UserName", authMessageSenderOption.UserName},
                    { "Password", authMessageSenderOption.Password}
                };
            }
        }
    }
