    internal class CriticalService : ICriticalService, IStartable
    {
        private readonly IEmailService email;
        public CriticalService(IEmailService email) {
            this.email = email;
        }
     ...
    }
