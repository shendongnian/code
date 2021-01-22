    public static bool TryParse( string text, out int number ) { .. }
    
    MethodInfo method = GetTryParseMethodInfo();
    object[] parameters = new object[]{ "12345", null }
    object result = method.Invoke( null, parameters );
    bool blResult = (bool)result;
    if ( blResult ) {
        int parsedNumber = (int)parameters[1];
    }
