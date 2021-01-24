    public static Response SendEmail(string apiKey, string senderEmail, string senderName, string recipientEmail, string recipientName, string subject, string content, bool html)
    {
        EmailHandler emailHandler = new EmailHandler();
        var responseTask =  emailHandler.SendEmail(apiKey, senderEmail, senderName, recipientEmail, recipientName, subject, content, html);
        responseTask.Wait(); // Wait for the task to complete
    
        return responseTask.Result;
    }
