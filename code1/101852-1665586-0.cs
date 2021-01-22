    public class Journal
    {
      private static Func<object, JournalEntry> _newJournalEntry;
    
      public class JournalEntry
      {
        static
        {
          _newJournalEntry = (object) => new JournalEntry(object);
        }
        private JournalEntry(object value)
        {
          ...
