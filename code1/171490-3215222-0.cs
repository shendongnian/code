    string input = "George Washington AND NOT Martha OR Dog";
    
    private string interpretSearchQuery(string input)
    {
        StringBuilder builder = new StringBuilder();
        var tokens = input.Split( ' ' );
    
        bool quoteOpen = false;
        foreach( string token in tokens )
        {
            if( !quoteOpen && !IsSpecial( token ) )
            {
                builder.AppendFormat( " \"{0}", token );
                quoteOpen = true;
            }
            else if( quoteOpen && IsSpecial( token ))
            {
                builder.AppendFormat( "\" {0}", token );
                quoteOpen = false;
            }
            else
            {
                builder.AppendFormat( " {0}", token );
            }
        }
    
        if( quoteOpen )
        {
            builder.Append( "\"" );
        }
    
        return "'" + builder.ToString().Trim() + "'";
    }
    
    public static bool IsSpecial( string token )
    {
        return string.Compare( token, "AND", true ) == 0 ||
            string.Compare( token, "OR", true ) == 0 ||
            string.Compare( token, "NOT", true ) == 0;
    }
