    public static List<string> SendMail(SubscriptionData data, Stream reportStream, string reportName, string smptServerHostname, int smtpServerPort)
    {
      List<string> failedRecipients = new List<string>();
    
      MailMessage emailMessage = new MailMessage(data.ReplyTo, data.To) {
          Priority = data.Priority,
          Subject = data.Subject,
          IsBodyHtml = false,
          Body = data.Comment
      };
    
      if (reportStream != null)
        emailMessage.Attachments.Add(new Attachment(reportStream, reportName));
      try
      {
          SmtpClient smtp = new SmtpClient(smptServerHostname, smtpServerPort);
    
          // Send the MailMessage
          smtp.Send(emailMessage);
      }
      catch (SmtpFailedRecipientsException ex)
      {
        // Delivery failed for the recipient. Add the e-mail address to the failedRecipients List
        failedRecipients.Add(ex.FailedRecipient);
        //are you missing a loop here? only one failed address will ever be returned
      }
      catch (SmtpFailedRecipientException ex)
      {
        // Delivery failed for the recipient. Add the e-mail address to the failedRecipients List
        failedRecipients.Add(ex.FailedRecipient);
      }
      // Return the List of failed recipient e-mail addresses, so the client can maintain its list.
      return failedRecipients;
    }
