    string description = "Card payment to tesco";
    List<string> keys = new List<string> {
    	{"Car" }, {"Card Payment" }
    };
    string desc = description.ToLowerInvariant( );
    string pattern = @"([{0}]+) (\S+)";
    var resp = keys.FirstOrDefault( a => {
    	var regx = new Regex( string.Format( pattern, a.ToLowerInvariant( ) ) );
    	return regx.Match( desc ).Success;
    } );
