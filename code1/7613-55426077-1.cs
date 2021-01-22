        public async Task DoWork()
        {
            _isBusy = true;
            while (!_worker.CancellationPending)
            {
                // Do something.
            }
            _isBusy = false;
        }
