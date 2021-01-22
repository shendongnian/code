    // utility method to recursively find controls matching a predicate
    IEnumerable<Control> FindRecursive( Control c, Func<Control,bool> predicate )
    {
        if( predicate( c ) )
            yield return c;
        foreach( var child in c.Controls )
        {
            if( predicate( c ) )
                yield return c;
        }
        foreach( var child in c.Controls )
            foreach( var match in FindRecursive( c, predicate ) )
               yield return match;
    }
    // use the utility method to find matching controls...
    FindRecursive( Page, c => (c is WebControl) && 
                              ((WebControl)c).CssClass == "instructions" );
