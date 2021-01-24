    [MethodImpl(MethodImplOptions.Synchronized)]
    public void Poll()
    {
        if (!_polling)
        {
            _polling = true;
            new Task(() =>
            {
                while (_currentSubscriptions.Count != 0)
                {
                    _consumer.Poll(TimeSpan.FromSeconds(1));
                }
                _polling = false;
            }, TaskCreationOptions.LongRunning).Start();
        }
    }
