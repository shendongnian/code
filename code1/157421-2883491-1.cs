    IDisposable LogAction(string message) {
        Logger.Write("Beginning " + message);
        return new DisposeHelper(() => Logger.Write("Ending " + message));
    }
    using (LogAction("Long task")) {
       Logger.Write("In long task");
    }
