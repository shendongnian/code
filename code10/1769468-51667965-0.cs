    public class ScheduleHostedService: BackgroundService
    {
        private readonly ILogger<ScheduleHostedService> _logger;
        private readonly DaemonSettings _settings;
        public ScheduleHostedService(IOptions<DaemonSettings> settings, ILogger<ScheduleHostedService> logger)
        {
            _logger = logger;
            _settings = settings.Value;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DateTime? callTime=null;
            if (_settings.StartAt.HasValue)
            {
                DateTime next = DateTime.Today;
                next = next.AddHours(_settings.StartAt.Value.Hour)
                    .AddMinutes(_settings.StartAt.Value.Minute)
                    .AddSeconds(_settings.StartAt.Value.Second);
                if (next < DateTime.Now)
                {
                    next = next.AddDays(1);
                }
                callTime = next;
            }
            if (_settings.StartDay.HasValue)
            {
                callTime = callTime ?? DateTime.Now;
                callTime = callTime.Value.AddDays(-callTime.Value.Day).AddDays(_settings.StartDay.Value);
                if (callTime < DateTime.Now)
                    callTime = callTime.Value.AddMonths(1);
            }
            if(callTime.HasValue)
                await Delay(callTime.Value - DateTime.Now, stoppingToken);
            else
            {
                callTime = DateTime.Now;
            }
            while (!stoppingToken.IsCancellationRequested)
            {
                //do smth
                var nextRun = callTime.Value.Add(_settings.RepeatEvery) - DateTime.Now;
                await Delay(nextRun, stoppingToken);
            }
        }
        static async Task Delay(TimeSpan wait, CancellationToken cancellationToken)
        {
            var maxDelay = TimeSpan.FromMilliseconds(int.MaxValue);
            while (wait > TimeSpan.Zero)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                var currentDelay = wait > maxDelay ? maxDelay : wait;
                await Task.Delay(currentDelay, cancellationToken);
                wait = wait.Subtract(currentDelay);
            }
        }
    }
