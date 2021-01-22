    public static List<data.Issue> Fetch<T>( string filter ) where T : FilterBase, new()
    {
        var filterBase = new T();
        filterBase.Initialize( filter );
    
        List<data.Issue> result;
        if ( IsNew( filter ) )
            result = filterBase.NewIssues();
        else if ( IsEnded( filter ) )
            result = filterBase.EndedIssues();
        else
            result = new List<data.Issue>();
    
        return result;
    }
