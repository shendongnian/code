    public void Send(EmailRequest emailRequest)
    {
    	try
    	{
    		// Creates the message itselft
    		EmailMessage message = new EmailMessage(ServiceExchange);
    		message.Body = new MessageBody(emailRequest.Message);
    		message.Subject = emailRequest.Subject;
    		message.ToRecipients.Add(emailRequest.To);
    
    		// Create a custom extended property and add it to the message. 
    		Guid myPropertySetId = Guid.NewGuid();
    		ExtendedPropertyDefinition myExtendedPropertyDefinition = new ExtendedPropertyDefinition(myPropertySetId, "MyExtendedPropertyName", MapiPropertyType.String);
    		message.SetExtendedProperty(myExtendedPropertyDefinition, "MyExtendedPropertyValue");
    
    		// Asynchronously, call
    		message.SendAndSaveCopy();
    
    		// Wait one second (while EWS sends and saves the message). 
    		System.Threading.Thread.Sleep(1000);
    	}
    	catch (Exception x)
    	{
    		logger.LogError(x.Message);
     
    	}
    }
