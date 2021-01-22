    Status status = new Status();
    ManualResetEvent changedEvent = new ManualResetEvent(false);
    Thread thread = new Thread(
        delegate() {
            status.Changed += delegate { changedEvent.Set(); };
            while (true) {
                changedEvent.WaitOne(Timeout.Infinite);
                int code = status.Code;
                DateTime lastUpdate = status.LastUpdate;
                changedEvent.Reset();
            }
        }
    );
    thread.Start();
