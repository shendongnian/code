    class Attachments : List<Attachment>, IDisposable
    {
      public void Dispose()
      {
        foreach (Attachment a in this)
        {
          a.Dispose();
        }
      }
    }
    
    class Mailer : IDisposable
    {
      SmtpClient client = new SmtpClient();
      Attachments attachments = new Attachments();
    
      public SendMessage()
      {
        [... do mail stuff ...]
      }
    
      public void Dispose()
      {
        this.client.Dispose();
        this.attachments.Dispose();
      }
    }
    
    
    [... somewhere else ...]
    using (Mailer mailer = new Mailer())
    {
      mailer.SendMail();
    }
