    public class MyService
    {
        private IEnumerable<IProvider> providers;
    
        public MyService(IEnumerable<IProvider> providers)
        {
            this.providers = providers;
        }
    
        public Task Action(UserInput input)
        {
            var provider = providers.FirstOrDefault(el => el.Type == SmsProvider);
        }
    }
