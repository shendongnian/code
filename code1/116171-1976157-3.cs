    public class BasicEmailDispatcher: EmailDispatcherBase {
        protected override SendEmailCore() {
            // Basic implementation goes here
        }
        protected override OnEmailFailed() {
            // Log the failure, maybe queue it for a later attempt
        }
    }
