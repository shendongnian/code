    ThreadPool.QueueUserWorkItem(t =>
    {
        SmtpClient client = new SmtpClient("MyMailServer");
        MailAddress from = new MailAddress("me@mydomain.com", "My Name", System.Text.Encoding.UTF8);
        MailAddress to = new MailAddress("someone@theirdomain.com");
        MailMessage message = new MailMessage(from, to);
        message.Body = "The message I want to send.";
        message.BodyEncoding =  System.Text.Encoding.UTF8;
        message.Subject = "The subject of the email";
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        // Set the method that is called back when the send operation ends.
        client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
        // The userState can be any object that allows your callback 
        // method to identify this send operation.
        // For this example, the userToken is a string constant.
        string userState = "some unique identifier for the message";
        client.SendAsync(message, userState);
        message.Dispose();
    });
    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        // Get the unique identifier for this asynchronous operation.
        String token = (string) e.UserState;
        if (e.Cancelled)
        {
             // prompt user with "send cancelled" message
        }
        if (e.Error != null)
        {
             // prompt user with error message
        } 
        else
        {
             // prompt user with message sent!
        }
    }
