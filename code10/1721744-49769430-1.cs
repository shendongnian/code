    foreach (var mail in emails)
    {
    	bool emailSent;
    	// Prepare single email here
       
    	try
    	{
    		// Try do send it here
    		// ....
            client.Send(mail);
    		// If the code comes here, it means the mail was sent
    		emailSent = true;
    	}
        catch 
        {
            // log the exception
        }
        Debug.WriteLine($"Email to {mail} status: {emailSent}");
    }
