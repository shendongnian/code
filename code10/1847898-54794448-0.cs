     // Getting the bot accessor state you want to use   
         
    LanguageAccessor languageAccessor = await _accessors.LanguageAccessor.GetAsync(turnContext, () => new LanguageAccessor(), cancellationToken);
        
        // Every step sends a response. If no dialog is active, no response is sent and turnContext.Responded is null
        //where turnContext.Activity.Text is the message sent by the user
       
     if (!turnContext.Responded && ((languageAccessor.property)turnContext.Activity.Text))
    
