    public static Stream ToEMLStream(this MailMessage msg)
    {
        using (var client = new SmtpClient())
        {
            var id = Guid.NewGuid();
    
            var tempFolder = Path.Combine(Path.GetTempPath(), Assembly.GetExecutingAssembly().GetName().Name);
    
            tempFolder = Path.Combine(tempFolder, "MailMessageToEMLTemp");
    
            // create a temp folder to hold just this .eml file so that we can find it easily.
            tempFolder = Path.Combine(tempFolder, id.ToString());
    
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
    
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            client.PickupDirectoryLocation = tempFolder;
            client.Send(msg);
    
            // tempFolder should contain 1 eml file
    
            var filePath = Directory.GetFiles(tempFolder).Single();
    
            // stream out the contents
            return new FileStream(filePath, FileMode.Open);
        }
    }
