    // Load message
    MailMessage message = new MailMessage();
    message.Load(@"c:\Temp\t\message.msg");
    // show From, To and Sent date
    Console.WriteLine("From: {0}", message.From);
    Console.WriteLine("To: {0}", message.To);
    Console.WriteLine("Sent: {0}", message.Date.LocalTime);
    
    // find and try to parse the first 'Received' header
    MailDateTime receivedDate = null;
    string received = message.Headers.GetRaw("Received");
    if (received != null)
    {
    	int lastSemicolon = received.LastIndexOf(';');
    	if (lastSemicolon >= 0)
    	{
    		string rawDate = received.Substring(lastSemicolon + 1);
    		MimeHeader header = new MimeHeader("Date", rawDate);
    		receivedDate = header.Value as MailDateTime;
    	}
    }
    
    // display the received date if available
    if (receivedDate != null)
    	Console.WriteLine("Received: {0}", receivedDate.LocalTime);
