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
