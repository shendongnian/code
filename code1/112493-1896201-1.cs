    class DateTimeExtended
    {
        public DateTime? MyDateTime;
        public int? otherdata;
        public DateTimeExtended() { }
        public DateTimeExtended(DateTimeExtended other)
        {
            this.MyDateTime = other.MyDateTime;
            this.otherdata = other.otherdata;
        }
    }
