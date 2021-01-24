    public static class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Play();
            Task.Delay(5000).Wait();
            game.Quit();
            game.Play();
            Task.Delay(15000).Wait();
            game.Quit();
            game.Play();
            Task.Delay(65000).Wait();
            Console.WriteLine("Main thread finished");
            Console.ReadKey();
			
			// Output:
			//
			// Start race (-00:00:00.0050018)
			// Quit called (00:00:05.0163131)
			// Timeout (00:00:05.0564685)
			// Start race (00:00:05.0569656)
			// Quit called (00:00:20.0585092)
			// Timeout (00:00:20.1025051)
			// Start race (00:00:20.1030095)
			// Escape (00:01:20.1052507)
			// Main thread finished
        }
    }
    internal class Game
    {
        private CancellationTokenSource _cts;
		// this is just to keep track of the behavior, should be removed
        private DateTime? _first;
        private DateTime First
        {
            get
            {
                if (!_first.HasValue) _first = DateTime.Now;
                return _first.Value;
            }
        }
        private async Task GetStop(CancellationToken token)
        {
            await Task.Run(async () =>
            {
                try
                {
					// we expect an exception here, if it is cancelled
                    await Task.Delay(TimeSpan.FromSeconds(60), token);
                }
                catch (Exception)
                {
                    Console.WriteLine("Timeout ({0})", DateTime.Now.Subtract(First));
                }
                if (!token.IsCancellationRequested)
                {
                    Console.WriteLine("Escape ({0})", DateTime.Now.Subtract(First));
                }
            }, token);
        }
        public async void Play()
        {
            Console.WriteLine("Start race ({0})", DateTime.Now.Subtract(First));
            CancelAndDisposeCts();
            _cts = new CancellationTokenSource();
            await GetStop(_cts.Token);
        }
        public void Quit()
        {
            Console.WriteLine("Quit called ({0})", DateTime.Now.Subtract(First));
            CancelAndDisposeCts();
        }
        private void CancelAndDisposeCts()
        {
			// avoid copy/paste for the same behavior
            if (_cts == null) return;
            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }
    }
