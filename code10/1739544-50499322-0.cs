    public class GaugeUpdater : BackgroundService {
        private readonly List<IUpdateable> _updatables;
        private Timer _timer;
        public GaugeUpdater (IEnumerable<IUpdateable> updateables) {
            _updatables = updateables.ToList();
            Updating += OnUpdating; //Subscribe to event
        }
        
        private event EventHandler Updating = delegate { };
        private async void OnUpdating(object sender, EventArgs args) {
            try {
                var tasks = _updatables.Select(x => x.Update());
                await Task.WhenAll(tasks);
            } catch {
                //TODO: Logging???
            }
        }
        
        private void UpdateAll(object state) {
            Updating(this, EventArgs.Empty); //Raise event
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            if (!stoppingToken.IsCancellationRequested) {
                await InitializeUpdateables();
                SetTimer();
            }
        }
        private void SetTimer() {
            const int intervalMilliseconds = 60_000;
            var interval = new TimeSpan(0, 0, 0, 0, intervalMilliseconds);
            _timer = new Timer(UpdateAll, null, interval, interval);
        }
        private async Task InitializeUpdateables() {
            var tasks = _updatables.Select(x => x.Initialize()).ToList();
            await Task.WhenAll(tasks);
        }
    }
