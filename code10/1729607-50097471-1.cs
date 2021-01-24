    public class MyControllerForTesting : MyController
    {
        private readonly IDictionary session;
        public MyControllerForTesting(IDictionary session) : base()
        {
            this.session = session;
        }
        protected override string ReadFromSession(string key)
        {
            return this.session[key];
        }
    
        protected override void StoreInSession(string key, string value)
        {
            this.session[key] = value;
        }
    }
