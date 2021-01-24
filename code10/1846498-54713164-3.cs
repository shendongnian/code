    [HttpPost]
    public async Task<ActionResult> SendEmail(EmailContentViewModel emailDetails)
    {
       using (MailMessage email = new MailMessage(emailDetails.from, emailDetails.to))
       {
           email.Subject = emailDetails.subject;
           email.Body = emailDetails.body;
           email.Priority = emailDetails.MailPriority;
           var result = await processSendingEmail(email);
           return RedirectToAction("ContactResult", "Contact", new { success = result }); 
       }
    }
    async Task<bool> processSendingEmail(System.Net.Mail.MailMessage email) {            
        await Task.Delay(1000); //email code here...
        return true;
    }
