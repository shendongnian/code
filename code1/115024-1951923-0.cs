        internal class LoggingService : ILoggingService {
        private readonly Queue<LogEntry> queue = new Queue<LogEntry>();
        private Thread waiter;
        public LoggingService() {
            waiter = new Thread(AddLogEntry);
            waiter.Start();
        }
        public void Shutdown() {
            try {
                waiter.Abort();
            } catch {}
        }
        public void Error(string s, Exception e) {
            lock (queue) {
                queue.Enqueue(new LogEntry(s, e, LogEntryType.Error));
            }
        }
        public void Warning(string message) {
            lock (queue) {
                queue.Enqueue(new LogEntry(message, LogEntryType.Warning));
            }
        }
        public void Info(string message) {
            lock (queue) {
                queue.Enqueue(new LogEntry(message, LogEntryType.Info));
            }
        }
        private void AddLogEntry(object state) {
            while (true) {
                lock (queue) {
                    if (queue.Count > 0) {
                        LogEntry logEntry = queue.Dequeue();
                        switch (logEntry.Type)
                        {
                            case LogEntryType.Error:
                                 logWriter.Error(logEntry.Message, logEntry.Exception);
                                break;
                            case LogEntryType.Warning:
                                logWriter.Warning(logEntry.Message);
                                break;
                            case LogEntryType.Info:
                                logWriter.Info(logEntry.Message);
                                break;
                        }
                    }
                }
                Thread.Sleep(100);
                if (waiter.ThreadState == ThreadState.Aborted) {
                    waiter = null;
                    break;
                }
            }
        }
    }
