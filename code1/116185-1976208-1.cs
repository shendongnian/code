    public void Submit() {
      try {
        SendMessage(emailForm.SenderAddress, emailForm.UserDisplayName,
          emailForm.RecipientEmails, emailForm.Subject, emailForm.MessageBody);
      } catch (MailException e) { // Substitute whichever exception is appropriate to catch here.
        // Tell user that submission failed for specified reasons.
      }
    }
