    public MyFunction(int integerParameter, string stringParameter){
        LogParameters(integerParameter, stringParameter);
    }
    
    public void LogParameters(params object[] values){
        // Get the parameter names from callstack and log names/values
    }
