         using System.Diagnostics;
         ...
         myLog = new EventLog("Security");
         myLog.EntryWritten += new EntryWrittenEventHandler(OnEntryWritten);
         ...
        /// <summary>
        /// A new event is logged in the security event log.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnEntryWritten(object source, EntryWrittenEventArgs e)
        {
            LogNewEntry(e.Entry);
        }
