        public class Journal
        {
            private static Func<object, JournalEntry> EntryFactory;
            public class JournalEntry
            {
                internal static void Initialize()
                {
                    Journal.EntryFactory = CreateEntry;
                }
                private static JournalEntry CreateEntry(object value)
                {
                    return new JournalEntry(value);
                }
                private JournalEntry(object value)
                {
                    this.Timestamp = DateTime.Now;
                    this.Value = value;
                }
                public DateTime Timestamp { get; private set; }
                public object Value { get; private set; }
            }
            static Journal()
            {
                JournalEntry.Initialize();
            }
            
            static JournalEntry CreateEntry(object value)
            {
                return EntryFactory(value);
            }
        }
