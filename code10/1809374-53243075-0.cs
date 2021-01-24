    byte[] applicationPDFData = actionResult.BuildPdf(ControllerContext);
    Attachment attPDF = new Attachment(new MemoryStream(applicationPDFData), name);
    EmailMessage emailMessage = new EmailMessage();
    emailMessage.To.Add( new EmailRecipient( toEmail ) );
    emailMessage.Subject = subject;
	emailMessage.Body = body;
    emailMessage.Attachments.Add( attPDF );
