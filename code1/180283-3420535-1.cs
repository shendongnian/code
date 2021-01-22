    public class NewAccountActivity : IActivity
    {
        private string userName;
        public NewAccountActivity(string userName)
        {
            this.userName = userName;
        }
        public string Log()
        {
            return this.UserName;
        }
    }
    public class ActivityEntry : IActivity
    {
        private Func<string> action;
    
        public ActivityEntry(Func<string> action)
        {
            this.action = action;
        }
    
        public string Log()
        {
            return this.action();
        }
    }
