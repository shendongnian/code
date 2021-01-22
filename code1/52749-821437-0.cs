    public static bool IsValid(int parameterName) {
      return (parameterName >= 0) && (parameterName <= 2);
    }
    
    public static void OnlyValidInput(int parameterName) {
      if ( !IsValid(parameterName) ) {
        throw new CustomExceptoin("...");
      }
      .. Do stuff
    }
