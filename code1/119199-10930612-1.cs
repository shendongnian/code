     //  Firstly you might want to use POP3Class which is mail support class.
         POP3Class Pop3= new POP3Class();***strong text***
         pop3.DoConnect("your.mail.server",110,"username","password");
         pop3.GetStat();
      //  and then you can use the below code for storing an attachment.
         MailMessage mail = new MailMessage ();
         Mail.Load (args[0]);
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
    // Hope that helps.
