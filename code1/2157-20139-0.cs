    static class Parser
    {
        public static bool TryParse<TType>( string str, out TType x )
        {
            // Get the type on that TryParse shall be called
            Type objType = typeof( TType );
            // Enumerate the methods of TType
            foreach( MethodInfo mi in objType.GetMethods() )
            {
                if( mi.Name == "TryParse" )
                {
                    // We found a TryParse method, check for the 2-parameter-signature
                    ParameterInfo[] pi = mi.GetParameters();
                    if( pi.Length == 2 ) // Find TryParse( String, TType )
                    {
                        // Build a parameter list for the call
                        object[] paramList = new object[2] { str, default( TType ) };
                        // Invoke the static method
                        object ret = objType.InvokeMember( "TryParse", BindingFlags.InvokeMethod, null, null, paramList );
                        // Get the output value from the parameter list
                        x = (TType)paramList[1];
                        return (bool)ret;
                    }
                }
            }
            // Maybe we should throw an exception here, because we were unable to find the TryParse
            // method; this is not just a unable-to-parse error.
            x = default( TType );
            return false;
        }
    }
