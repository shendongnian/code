    // somewhere ...
    public static IDictionary<Type, string> exceptionMessages;
    // in your method ...
    try { ... }
    catch( Exception ex ) {        
        var exType = ex.GetType();
        if( exceptionMessages.ContainsKey(exType) ) {
            MessageBox.Show( exceptionMessages[exType] );
        }
        else {
            throw ex;
        }
    }
