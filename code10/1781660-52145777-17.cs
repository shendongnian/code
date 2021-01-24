    public static class UpdaterEvent 
    {
        public static event EventHandler DataUpdated;
    
        public static void PublishDataUpdated(EventArgs args) 
        {
            var updaterEvent = DataUpdated;
            if (updaterEvent != null)
                updaterEvent(null, args);
        }
    }
