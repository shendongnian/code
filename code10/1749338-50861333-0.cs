    public class MailHandler
    {
        private EmailLibrary emailLibrary = new EmailLibrary();
        private ExecutionDataflowBlockOptions options = new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };
        private ActionBlock<string> messageHandler;
        public MailHandler() => messageHandler = new ActionBlock<string>(msg => DelegateSendEmail(msg), options);
        public Task ProcessMail(string message) => messageHandler.SendAsync(message);
        public Task DelegateSendEmail(string message) => emailLibrary.SendEmail(message);
    }
    public class EmailLibrary
    {
        public Task SendEmail(string message) => Task.Delay(1000);
    }
}
