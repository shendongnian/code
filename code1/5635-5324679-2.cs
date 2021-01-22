    public static void CopyTo( this object S, object T )
    {
        foreach( var pS in S.GetType().GetProperties() )
        {
            foreach( var pT in T.GetType().GetProperties() )
            {
                if( pT.Name != pS.Name ) continue;
                ( pT.GetSetMethod() ).Invoke( T, new object[] 
                { pS.GetGetMethod().Invoke( S, null ) } );
            }
        };
    }
