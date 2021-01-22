    genSess = fbSess;              // ok, implicit cast to generic type
    fbSess  = genSess;             // ILLEGAL, it may not be a FacebookSession
    fbSess  = (FacebookSession) genSess; 
                                   // legal but can throw an exception
    
