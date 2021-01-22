    using Rebex.Mail;
    using Rebex.Mime.Headers;
    
    // create an instance of MailMessage  
    MailMessage message = new MailMessage();
    
    // load the message from a local disk file  
    message.Load("c:\\message.eml");
    
    Console.Write(message.From);
    Console.Write(message.To)
    foreach (Attachment attachment in message.Attachments)
    {
    	// Save the file 
    	Console.WriteLine ("Saving '{0}' ({1}).", 
    	 attachment.FileName, attachment.MediaType);
    	attachment.Save (attachment.FileName);
    }
