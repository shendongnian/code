    protected string Linkify( string SearchText ) {
        // this will find links like:
        // http://www.mysite.com
        // as well as any links with other characters directly in front of it like:
        // href="http://www.mysite.com"
        // you can then use your own logic to determine which links to linkify
        Regex regx = new Regex( @"\b(((\S+)?)(@|mailto\:|(news|(ht|f)tp(s?))\://)\S+)\b", RegexOptions.IgnoreCase );
        SearchText = SearchText.Replace( "&nbsp;", " " );
        MatchCollection matches = regx.Matches( SearchText );
    
        foreach ( Match match in matches ) {
            if ( match.Value.StartsWith( "http" ) ) { // if it starts with anything else then dont linkify -- may already be linked!
                SearchText = SearchText.Replace( match.Value, "<a href='" + match.Value + "'>" + match.Value + "</a>" );
            }
        }
    
        return SearchText;
    }
