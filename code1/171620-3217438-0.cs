      MailMessage m = new MailMessage(_gmailEmail, _to);
      m.Subject = _emailSubject;
      m.Body = _body;
      for (int i = 0; i < lstAttachments.Items.Count ; i++) // your list
        m.Attachments.Add(new Attachment("\path\to\file\to\attach\here"));
