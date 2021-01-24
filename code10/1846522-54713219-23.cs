    [HttpPost]
    public async Task<ActionResult> SendEmail(EmailContentViewModel emailDetails)
    {
        using (MailMessage email = new MailMessage(emailDetails.from, emailDetails.to))
        {
            email.Subject = emailDetails.subject;
            email.Body = emailDetails.body;
            email.Priority = emailDetails.MailPriority;
            var message=await MySendMethod(email);
            return RedirectToAction("ContactResult", "Contact", 
                       new { success = String.IsNullOrWhitespace(result),
                             message=message 
                       }); 
        };
    }
