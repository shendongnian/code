    Task StartProcessMessage(Message m) {
        //...
    }
    public async Task Start() {
        while (true) {
            var messages = (await _queueClient.ReceiveBatchAsync(Math.Max(1, _configuration.MaxConcurrentCalls - _messagesInProgress))).ToArray();
            Interlocked.Add(ref _messagesInProgress, messages.Length);
            var tasks = messages.Select(m => StartProcessMessage(m));
            await Task.WhenAll(tasks); //process in parallel.
            while (_messagesInProgress > _configuration.MaxConcurrentCalls) {
                await Task.Delay(100);
            }
        }
    }
