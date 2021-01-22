    public void LogMatches( string inputText )
    {
        var @TomalaksPattern = @"\{\(([A-Z]{2})?\d{6}\)\}"; // trusting @Tomalak on this, didn't verify
        MatchCollection matches = Regex.Matches( inputText, @TomalaksPattern );
        foreach( Match m in matches )
        {
            if( Regex.Match( m.Value, @"\D" ) )
                 Log( "Letter type match {0} at index {1}", m.Value, m.Index );
            else
                Log( "No letters match {0} at index {1}", m.Value, m.Index );
        }
    }
