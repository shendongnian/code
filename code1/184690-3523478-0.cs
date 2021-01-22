    FacebookSession fbSess;
    IAPISession     genSess;
    FacebookSession getFbSession() { ... return this; }
    IAPISession     getSession()   { ... return this; }
    
    genSess = getSession();        // legal
    genSess = getFbSession();      // legal - implicit cast works as FacebookSession 
                                   // is always a kind of IAPISession
    fbSess  = getFbSession();      // legal
    fbSess  = getSession();        // ILLEGAL - not all IAPISession's will be
                                   // kinds of FacebookSession
    fbSess  = (FacebookSession) getSession();
                                   // legal, but might throw a class cast exception
                                   // if it isn't a FacebookSession.
   
