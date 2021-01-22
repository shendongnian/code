    public class MockSmtpClient()
    {
       public string From { get; set; }
       public string To { get; set; }
       public void Send(MailMessage message) { }
    }
