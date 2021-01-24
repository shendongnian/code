    public class SettingsScorable : ScorableBase<IActivity, string, double>
    {
        private readonly IDialogTask task;
        public SettingsScorable(IDialogTask task)
        {
            ...
        }
    
        protected override async Task<string> PrepareAsync(IActivity activity, CancellationToken token)
        {
            ...
        }
    
        protected override bool HasScore(IActivity item, string state)
        {
            ...
        }
    
        protected override double GetScore(IActivity item, string state)
        {
            ...
        }
        
        protected override async Task PostAsync(IActivity item, string state, CancellationToken token)
        {
            ...
        }
    
        protected override Task DoneAsync(IActivity item, string state, CancellationToken token)
        {
            ...
        }
    }
