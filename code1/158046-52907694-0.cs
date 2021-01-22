    public class DailyTraceListener : TraceListener
    {
        public bool UseUtcTime { get; private set; }
        public string LogFolder { get; private set; }
        public bool Disposed { get; private set; }
        public bool HasHeader { get; private set; }
        public string CurrentLogFilePath { get; private set; }
        protected DateTime? CurrentLogDate { get; set; }
        protected FileStream LogFileStream { get; set; }
        protected StreamWriter LogFileWriter { get; set; }
        private SemaphoreSlim LogLocker { get; set; } = new SemaphoreSlim(1, 1);
        public DailyTraceListener(string logFolder)
        {
            this.LogFolder = logFolder;
        }
        public DailyTraceListener UseUtc()
        {
            this.UseUtcTime = true;
            return this;
        }
        public DailyTraceListener UseHeader()
        {
            this.HasHeader = true;
            return this;
        }
        protected virtual void WriteHeader()
        {
            this.LogFileWriter.WriteLine(string.Format("{0},{1},{2},{3},{4}",
                "Time",
                "Type",
                "Source",
                "ID",
                "Message"));
        }
        protected virtual string FormatTime(DateTime time)
        {
            return time.ToString("o");
        }
        private DateTime GetCurrentTime()
        {
            if (this.UseUtcTime)
            {
                return DateTime.UtcNow;
            }
            else
            {
                return DateTime.Now;
            }
        }
        private void InitializeLogFile()
        {
            this.CheckDisposed();
            try
            {
                if (this.LogFileWriter != null)
                {
                    this.LogFileWriter.Dispose();
                }
                if (this.LogFileStream != null)
                {
                    this.LogFileWriter.Dispose();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            var currentTime = this.GetCurrentTime();
            var fileName = $"{currentTime.ToString("yyyy-MM-dd")}.log";
            this.CurrentLogFilePath = Path.Combine(this.LogFolder, fileName);
            // Ensure the folder is there
            Directory.CreateDirectory(this.LogFolder);
            // Create/Open log file
            this.LogFileStream = new FileStream(this.CurrentLogFilePath, FileMode.Append);
            this.LogFileWriter = new StreamWriter(this.LogFileStream);
            // Write Header if needed
            if (this.LogFileStream.Length == 0 && this.HasHeader)
            {
                this.WriteHeader();
            }
        }
        private void CheckFile()
        {
            this.CheckDisposed();
            var currentTime = this.GetCurrentTime();
            if (this.CurrentLogDate == null || currentTime.Date != this.CurrentLogDate)
            {
                this.InitializeLogFile();
                this.CurrentLogDate = currentTime.Date;
            }
        }
        private void CheckDisposed()
        {
            if (this.Disposed)
            {
                throw new InvalidOperationException("The Trace Listener is Disposed.");
            }
        }
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            var time = this.FormatTime(this.GetCurrentTime());
            this.WriteLine(string.Format("{0},{1},{2},{3},{4}",
                time,
                eventType,
                EscapeCsv(source),
                id.ToString(),
                EscapeCsv(message)));
        }
        public override void Write(string message)
        {
            try
            {
                this.LogLocker.Wait();
                this.CheckDisposed();
                this.CheckFile();
                var currentTime = this.GetCurrentTime();
                this.LogFileWriter.Write(message);
                this.LogFileWriter.Flush();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            finally
            {
                this.LogLocker.Release();
            }
        }
        public override void WriteLine(string message)
        {
            this.Write(message + Environment.NewLine);
        }
        protected string EscapeCsv(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',' || input[i] == '\n')
                {
                    input = input.Replace("\"", "\"\"");
                    return $"\"{input}\"";
                }
            }
            return input;
        }
        protected override void Dispose(bool disposing)
        {
            this.Disposed = true;
            try
            {
                this.LogFileWriter?.Dispose();
                this.LogFileStream?.Dispose();
                this.LogLocker.Dispose();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            base.Dispose(disposing);
        }
    }
