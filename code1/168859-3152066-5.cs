    public interface IMonitoredDisposable : IDisposable
    {
      bool IsDisposed { get; set; }
    }
    
