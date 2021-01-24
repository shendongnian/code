    public sealed class Hotel
    {
        private readonly DateTime _closingTime;
        public Hotel(DateTime closingTime) => _closingTime = closingTime;
        public bool IsOpenAt(DateTime time) => time.TimeOfDay <= _closingTime.TimeOfDay;
    }
