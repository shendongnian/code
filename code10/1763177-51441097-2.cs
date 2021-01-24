    void aync Task UpdateCounterAsync(int newValue)
    {
        var oldValue = _counter;
        _counter = newValue;
        _cancellationSourceToken.Cancel();
        _cancellationSourceToken = new CancellationSourceToken();
        try
        {
            await Task.Delay(Timespan.FromSeconds(5), _cancellationSourceToken.Token);
            if (_counter == oldValue)
            {
                // counter is still the same; do something
            }
        }
        catch (TaskCancelledException)
        {
            // another update has been triggered while we were waiting. 
            // _counter has obviously changed then bail out
        }
    }
