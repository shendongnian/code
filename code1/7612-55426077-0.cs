        public async Task StopAsync()
        {
            _worker.CancelAsync();
    
            while (_isBusy)
                await Task.Delay(1);
        }
    
