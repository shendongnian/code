    public class Journal
    {
        private static Func<object, JornalEntry> EntryFactory;
        public class JournalEntry
        {
            static JornalEntry()
            {
                Journal.EntryFactory = CreateEntry;
            }
            private static JornalEntry CreateEntry(object value)
            {
                return new JornalEntry(value);
            }
            private JournalEntry(object value)
            {
                this.Timestamp = DateTime.Now;
                this.Value = value;
            }
            public DateTime Timestamp { get; private set; }
            public object Value { get; private set; }
        }
    //...
    }
