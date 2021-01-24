    void aync Task UpdateCounterAsync(int newValue)
    {
        var oldValue = _counter;
        _counter = newValue;
        await Task.Delay(Timespan.FromSeconds(5));
        if (_counter == oldValue)
        {
            // counter is still the same; do something
        }
    }
