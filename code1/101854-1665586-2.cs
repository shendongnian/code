    public class Journal
    {
      private static Func<object, JournalEntry> _newJournalEntry;
    
      public class JournalEntry
      {
        static JournalEntry()
        {
          _newJournalEntry = value => new JournalEntry(value);
        }
        private JournalEntry(object value)
        {
          ...
