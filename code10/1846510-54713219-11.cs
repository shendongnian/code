    [HttpPost]
    public async Task<ActionResult> SendEmail(EmailContentViewModel emailDetails)
    {
        var client = new MailKit.Net.Smtp.SmptClient();
        /Configure the client here ...
        using (MailMessage email = new MailMessage(emailDetails.from, emailDetails.to))
        {
            email.Subject = emailDetails.subject;
            email.Body = emailDetails.body;
            email.Priority = emailDetails.MailPriority;
            var msg=(MailKit)email;
            await client.SendAsync(msg);
            return RedirectToAction("ContactResult", "Contact", new { success = true }); 
        };
    }
