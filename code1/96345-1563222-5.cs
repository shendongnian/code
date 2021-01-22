    public void TryThreeTimes(Action action)
    {
        var tries = 3;
        while (true) {
            try {
                action();
                break; // success!
            } catch {
                if (--tries == 0)
                    throw;
                Thread.Sleep(1000);
            }
        }
    }
