    using System.Timers;
    namespace wpf_GlobalTimer
    {
        public static class TimerParent
        {
            public static Timer GlobalTimer { get; set; } = new Timer(3000)
            {
                AutoReset = true,
                Enabled = true
            };
        }
    }
