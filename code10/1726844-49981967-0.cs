    public class OneTimeStopwatch : IDisposable
    {
        private string _logPath = "C:\\Temp\\OneTimeStopwatch.log";
        private readonly string _itemname;
        private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    
        public OneTimeStopwatch(string itemname)
        {
            _itemname = itemname;
            sw.Start();
        }
    
        public void Dispose()
        {
            sw.Stop();
            System.IO.File.AppendAllText(_logPath, string.Format($"{_itemname}: {sw.ElapsedMilliseconds}ms{Environment.NewLine}"));
        }
    }
