    public class DayChangedEventArgs : EventArgs
    {
        public DayChangedEventArgs(DayOfWeek day)
        {
            this.DayOfWeek = day;
        }
        public DayOfWeek DayOfWeek { get; private set; }
    }
