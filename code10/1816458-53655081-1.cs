<!-- -->
    public class ApplicationHub : Hub<IClient>
    {
        public CustomTimer timer = new CustomTimer(1000);
        // Change this ↓ to `static`, so that `timer.Elapsed -= aTimer_Elapsed;` works
        static void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Change this ↓ to `var`
            var timer = (CustomTimer)sender;
            // ...
        }
        public async Task StartTime()
        {
            // Add this ↓
            timer = CustomTimer.Timers.GetOrAdd(Context.ConnectionId, timer);
            // ...
        }
        public async Task StopTime()
        {
            // Add this ↓
            timer = CustomTimer.Timers.GetOrAdd(Context.ConnectionId, timer);
            // ...
        }
    }
