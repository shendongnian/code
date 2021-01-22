    ...
    bool UseAuth
    virtual string RequestURI
    {
       get
       {
          if(useAuth)
             return _requestURIAuthBased;
          else
             _requestURI;
       }
    }
    ....
