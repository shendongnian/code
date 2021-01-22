    public static class UniqueId
    {
        static private int _InternalCounter = 0;
        static public string Get()
        {
            var now = DateTime.Now;
            var days = (int)(now - new DateTime(2000, 1, 1)).TotalDays;
            var seconds = (int)(now - DateTime.Today).TotalSeconds;
            var counter = _InternalCounter++ % 100;
            return days.ToString("00000") + seconds.ToString("00000") + counter.ToString("00");
        }
