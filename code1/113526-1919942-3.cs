    string status;
    lock (driverLock) {
        if (!active) { return; }
        status = ...
        actionTimer.Change(500, Timeout.Infinite);
    }
    StatusEvent(this, new StatusEventArgs(status));
