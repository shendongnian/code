    [HttpPost]
    public async Task<ActionResult> SendEmail(EmailContentViewModel emailDetails)
    {
        SmptClient client = ... //Configure the client here
        using (MailMessage email = new MailMessage(emailDetails.from, emailDetails.to))
        {
            email.Subject = emailDetails.subject;
            email.Body = emailDetails.body;
            email.Priority = emailDetails.MailPriority;
            await client.SendMailAsync(email);
            return RedirectToAction("ContactResult", "Contact", new { success = result }); 
        };
    }
