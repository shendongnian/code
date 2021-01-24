    class Term {
        String Field;
        String Value;
    }
    String input = "O'Brien firstname:John";
    Term[] terms = GetTerms( input ); // returns the array from step 3
    
    IQueryable<Owner> query = db.Owners;
    foreach( Term term in terms ) {
        
        switch( term.Field.ToUpperInvariant() ) {
            case null:
            case "ANY":
                query = query.Where( o => o.LastName.Contains( term.Value ) || o.FirstName.Contains( term.Value ) || o.Title.Contains( term.Value ) || o.Suffix.Contains( term.Value ) );
                break;
            case "FIRST":
                query = query.Where( o => o.FirstName.Cotains( term.Value ) );
                break;
            case "LAST":
                query = query.Where( o => o.LastName.Contains( term.Value ) );
                break;
            case "TITLE":
                // et cetera...
        }
    }
    List<Owner> results = query.ToList();
    
