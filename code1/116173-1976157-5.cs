    public class EmailDispatcherWithLogging: EmailDispatcherBase {
        protected override OnEmailFailed() {
            // Write a failure log entry to the database
        }
    }
