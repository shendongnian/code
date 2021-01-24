    public class GlobalTimer : Timer
    {
        private GlobalTimer instance;
        public GlobalTimer Instance => instance ?? (instance = new GlobalTimer());
        private GlobalTimer()
        {
        }
    }
