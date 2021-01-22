    void someAction( untrustedData ) {
      trustedData = object;
      trustedData.id      = makeInt( badData.id );
      trustedData.name    = safeCharsOnly( untrustedData.name ); 
      trustedData.message = safeCharsOnly( untrustedData.message ); # <-- spam-check this 
  
      fieldsToSpamCheck = ['message']; 
      successUrlBase = '/myapp/sandwiches/postMessage';
      if (!spamChecker.check( trustedData, fieldsToSpamCheck, successUrlBase )) {
        // spamChecker will check specified params
        //  if not spam, it returns true
        //  if spam it sets a http redirect and returns false
        return;
      }
      processData( trustedData );
  }
