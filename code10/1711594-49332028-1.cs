    [HttpPost]
    public ActionResult SendEmail(SendEmail obj)
    {
    
        try
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("OutgoingEmailAddress", "OutgoingEmailAddressPassword");
    
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("OutgoingEmailAddress@gmail.com");
            mailMessage.To.Add("TargetEmailAddress@gmail.com");
            mailMessage.Body = "body";
            mailMessage.Subject = "subject";
            client.Send(mailMessage);
    
            ViewBag.Status = "Email Sent Successfully.";
        }
        catch (Exception ex)
        {
            //handle exception
        }
        return View("XYZ");
    }
