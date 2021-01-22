    public interface ILogStore
    {
        IEnumerable<LogMessage> GetMessages();
        IEnumerable<LogMessage> GetMessagesBySubsystem(string subsystem);
    }
