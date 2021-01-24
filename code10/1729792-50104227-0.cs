    try{
      ctxDomain = GetDomainContext(out bErrorHittingDomainServer);
      //The other code inside the using block
    }
    finally{
     if(ctxDomain != null){
        ctxDomain.Dispose();
      }
    }
