    public struct CustomDateTime
    {
        private readonly DateTime _date;
        public CustomDateTime(DateTime date)
        {
            _date = date;
        }
        public override string ToString()
        {
            return _date.ToString("custom format");
        }
    }
