    private readonly Thread _consumerThread;
    public LogManager() {
        new Thread(() => {
            Thread.CurrentThread.Name = "Logger";
            try {
                foreach (string message in queueLogMinimal.GetConsumingEnumerable()) {
                    try {
                        LogMinimal(message);
                    }
                    catch (Exception ex) {
                        // do something, otherwise one failure to write a log
                        // will bring down your whole logging
                    }
                }
            }
            catch (Exception ex) {
                // do something, don't let exceptions go unnoticed
            }
        }) {
            IsBackground = true
        }.Start();
    }
