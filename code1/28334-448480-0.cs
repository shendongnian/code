    //Example
    enum ErrorCodes
    {
      BusinessObjectNotFound = 1000,
      AnotherPossibleError = 1002
    }
    try
    {
    //Code
    }
    Catch(BusinessObjectNotFoundException bex)
    {
      throw new SoapException(ErrorCodes.BusinessObjectNotFound);
      //Or maybe...
      //throw new SoapException(((int)ErrorCodes.BusinessObjectNotFound).ToString());
    }
