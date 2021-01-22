        public class Journal
        {
           public class JournalEntry
            {
                protected JournalEntry(object value)
                {
                    this.Timestamp = DateTime.Now;
                    this.Value = value;
                }
                public DateTime Timestamp { get; private set; }
                public object Value { get; private set; }
            }
           private class JournalEntryInstance: JournalEntry
           { 
                public JournalEntryInstance(object value): base(value)
                {}
           }
           JournalEntry CreateEntry(object value)
           {
               return new JournalEntryInstance(value);
           }
        }
