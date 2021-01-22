    try {
      RunMyStoredProcedure();
    }
    catch(OracleException e) {
      new OracleExceptionProcessor().HandleException(e);
    }
    //...
    //...
    class OracleExceptionProcessor {
      static List<int> _validationErrorCodes = new List<int> { 123, 456};
      static List<int> _authenticationErrorCodes = new List<int> { 789};
    
      public void HandleException(OracleException ex) {
        if(_validationErrorCodes.Any(c==ex.ErrorCode))
          throw new DatabaseValidationError(ex);
        if(_authenticationErrorCodes.Any(c==ex.ErrorCode))
          throw new DatabaseAuthenticationError(ex);
        throw new DatabaseSQLError(ex);
      }
    }
