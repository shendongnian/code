    private static void UploadMIMEEmail(ExchangeService service)
    {
        EmailMessage email = new EmailMessage(service);
    
        string emlFileName = @"C:\import\email.eml";
        using (FileStream fs = new FileStream(emlFileName, FileMode.Open, FileAccess.Read))
        {
            byte[] bytes = new byte[fs.Length];
            int numBytesToRead = (int)fs.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                int n = fs.Read(bytes, numBytesRead, numBytesToRead);
                if (n == 0)
                    break;
                numBytesRead += n;
                numBytesToRead -= n;
            }
            // Set the contents of the .eml file to the MimeContent property.
            email.MimeContent = new MimeContent("UTF-8", bytes);
        }
    
        // Indicate that this email is not a draft. Otherwise, the email will appear as a 
        // draft to clients.
        ExtendedPropertyDefinition PR_MESSAGE_FLAGS_msgflag_read = new ExtendedPropertyDefinition(3591, MapiPropertyType.Integer);
        email.SetExtendedProperty(PR_MESSAGE_FLAGS_msgflag_read, 1);
        // This results in a CreateItem call to EWS. The email will be saved in the Inbox folder.
        email.Save(WellKnownFolderName.Inbox);
    }
