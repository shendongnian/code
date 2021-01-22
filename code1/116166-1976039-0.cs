    public interface IEmailDispatcher
    {
        void SendEmail(string[] to, string fromName, string fromAddress, string subject, string body, bool bodyIsHTML, Dictionary<string, byte[]> Attachments);
        event EmailSentEventHandler EmailSent;
        event EmailFailedEventHandler EmailFailed;
    }
