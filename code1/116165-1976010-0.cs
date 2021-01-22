    public interface IEmailDispatcher
    {
        event EventHandler EmailSent;
        void SendEmail(string[] to, string fromName, string fromAddress, string subject, string body, bool bodyIsHTML, Dictionary<string, byte[]> Attachments);
    }
