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
                query = query.Where( o => o.LastName = term.Value || o.FirstName == term.Value || o.Title == term.Value || o.Suffix == term.Value );
                break;
            case "FIRST":
                query = query.Where( o => o.FirstName == term.Value );
                break;
            case "LAST":
                query = query.Where( o => o.LastName == term.Value );
                break;
            case "TITLE":
                // et cetera...
        }
    }
    List<Owner> results = query.ToList();
    
