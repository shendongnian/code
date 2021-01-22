    var client = new SmtpClient();
    var folder = new RandomTempFolder();
    client.DeliveryMethod = 
      SmtpDeliveryMethod.SpecifiedPickupDirectory;
    client.PickupDirectoryLocation = folder.FullName;
    var message = new MailMessage("to@no.net",
      "from@no.net", "Subject","Hi and bye");
    // add attachments here, if needed
    // need this to open email in Edit mode in OE
    message.Headers.Add("X-Unsent", "1");
    client.Send(message);
    var files = folder.GetFiles();
    Process.Start(files[0].FullName);
