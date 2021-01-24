    static void Main(string[] args)
    {
          ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
          service.Credentials = new WebCredentials("user1@contoso.com", "password");
          service.TraceEnabled = true;
          service.TraceFlags = TraceFlags.All;
          service.AutodiscoverUrl("user1@contoso.com", RedirectionUrlValidationCallback);
          
          var messages = new List<EmailMessage>();
          // only get unread emails
          SearchFilter folderSearchFilter = new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false);
         // we just need the id in our results
         var itemView = new ItemView(10) {PropertySet = new PropertySet(BasePropertySet.IdOnly)};
         FindItemsResults<Item> findResults = service.FindItems(folder.Id, folderSearchFilter, itemView);
          
         foreach (Item item in findResults.Items.Where(i => i is EmailMessage))
         {
            EmailMessage message = EmailMessage.Bind(service, item.Id, new PropertySet(BasePropertySet.IdOnly, ItemSchema.Attachments, ItemSchema.HasAttachments));
            messages.Add(message);
         }
      // loop through messages and call processemail here.
    }
    public static void ProcessEmail(EmailMessage message)
    {
         string saveDir = ConfigurationManager.AppSettings["AttachmentSaveDirectory"];
         if (message.HasAttachments)
         {
            foreach (Attachment attachment in message.Attachments.Where(a=> a is FileAttachment))
            {
                FileAttachment fileAttachment = attachment as FileAttachment;
                fileAttachment.Load(); // populate the content property of the attachment
                using (FileStream fs = new FileStream(saveDir + attachment.Name, FileMode.Create))
                {
                   using (BinaryWriter w = new BinaryWriter(fs))
                   {
                      w.Write(fileAttachment.Content);
                   }
                }
            }
        }
    message.IsRead = true;
    message.Update(ConflictResolutionMode.AutoResolve); // push changes back to server
    }
    private static bool RedirectionUrlValidationCallback(string redirectionUrl)
    {
         // The default for the validation callback is to reject the URL.
         bool result = false;
         Uri redirectionUri = new Uri(redirectionUrl);
         // Validate the contents of the redirection URL. In this simple validation
         // callback, the redirection URL is considered valid if it is using HTTPS
        // to encrypt the authentication credentials. 
        if (redirectionUri.Scheme == "https")
        {
           result = true;
        }
           return result;
    }
