    public class DebugActivityLogger : IActivityLogger
    {
        public async Task LogAsync(IActivity activity)
        {
            Debug.WriteLine(activity.AsMessageActivity()?.Text);
        }
    }
