    public class DownloadManager : IDisposable
    {
        private readonly SemaphoreSlim _throttler = new SemaphoreSlim(4);
        public async Task<DownloadResult> DownloadAsync(DownloadRequest request)
        {
            await _throttler.WaitAsync();
            try
            {
                return await api.Download(request);
            }
            finally
            {
                _throttler.Release();
            }
        }
        public void Dispose()
        {
            _throttler?.Dispose();
        }
    }
