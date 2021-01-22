    public class HistoryEntry : IComparable<HistoryEntry>
    {
        public DateTime Date { get; set; }
        public HistoryType HistoryType { get; set; }
        public int CompareTo(HistoryEntry other)
        {
            return this.Date.CompareTo(other.Date);
        }
    }
