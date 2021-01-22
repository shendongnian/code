    void Main()
    {
    	string test = "here is some code `public void Method( )` but ``this is not code``";
    	Regex r = new Regex( @"(`[^`]+`)" );
    	
    	MatchCollection matches = r.Matches( test );
    	
    	foreach( Match match in matches )
    	{
    		Console.Out.WriteLine( match.Value );
    		if( test[match.Index - 1] == '`' )
    			Console.Out.WriteLine( "NOT CODE" );
                else
			Console.Out.WriteLine( "CODE" );
    	}
    }
