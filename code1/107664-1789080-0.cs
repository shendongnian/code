    public void ShowFloatingForXMilliSeconds(int milliSeconds) {
        ShowFloating();
        if (_autoOffTimer == null) {
            _autoOffTimer = new System.Timers.Timer();
            _autoOffTimer.Elapsed += OnAutoOffTimerElapsed;
            _autoOffTimer.SynchronizingObject = this;
        }
        _autoOffTimer.Interval = milliSeconds;
        _autoOffTimer.Enabled = true;
    }
    void OnAutoOffTimerElapsed(Object sender, System.Timers.ElapsedEventArgs ea) {
        if ((_autoOffTimer != null) && _autoOffTimer.Enabled) {
            _autoOffTimer.Enabled = false;
            HideFloating();
        }
    }
