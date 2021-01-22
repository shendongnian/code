    public void MailToAFriend(string friendMailAddress, Uri uriToEmail) {
      MailMessage message = new MailMessage();
      message.From = "your_email_address@yourserver.com";
      message.To = friendEmailAddress;
      message.Subject = "Check out this awesome page!";
      message.Body = GetPageContents(uriToEmail);
      
      SmtpClient mailClient = new SmtpClient();
      mailClient.Send(message);
    }
    private string GetPageContents(Uri uri) {
      var webClient = new WebClient();
      string dirtyHtml = webClient.DownloadString(uri);
      string cleanedHtml = MakeReadyForEmailing(dirtyHtml); 
      return cleanedHtml;
    }
    private string MakeReadyForEmailing(string html) {
      // some implementation to replace any significant relative link 
      // with absolute links, strip javascript, etc
    }
