    // Load mail message from disk 
    MailMessage mail = new MailMessage ();
    mail.Load (args[0]);
    
    Console.WriteLine (
    	"Message contains {0} attachments.", 
    	mail.Attachments.Count
    );
    
    // If message has no attachments, just exit 
    if (mail.Attachments.Count == 0)
    	return 0;
    
    foreach (Attachment attachment in mail.Attachments)
    {
    	// Save the file 
    	Console.WriteLine ("Saving '{0}' ({1}).", 
    	 attachment.FileName, attachment.MediaType);
    	attachment.Save (attachment.FileName);
    }
