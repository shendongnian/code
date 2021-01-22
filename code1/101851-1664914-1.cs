    public interface IJournalEntry
    {
    }
    public class Journal
    {
        public IEnumerable<IJournalEntry> Entries
        {
            get { ... }
        }
        private class JournalEntry : IJournalEntry
        {
        }
    }
