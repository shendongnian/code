    public static class JournalBase {
        public static  void JournalBase_Modified()
        {
        if (evntJournalModified != null)
            evntJournalModified();
        }
    };
