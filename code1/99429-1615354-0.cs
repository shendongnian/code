    class SearchSystem
    {
        //link to the next in the chain 
        SearchSystem next;
 
        // Basic search, If cannot handle forward to the next.
        public Result search( Criteria c ) 
        {
            Result r = doSearch( c );
            if( r != null ) 
            {
                return r;
            }
            return next.search( c );
        }
        // subclass specific system search
        abstract Result doSearch( Criteria c );
    }
    class SearchSystemOne: SearchSystem 
    {
        Result doSearch( Criteria c )
        {
            // do some system 1 speficif stuff 
            // and return either and instance or null
        }
    }
    class SearchSystemTwo: SearchSystem 
    {
        Result doSearch( Criteria c )
        {
            // do some system 2 speficif stuff 
            // and return either and instance or null
        }
    }
    .... etc etc. 
    // End of the chain
    class SearchSystemOver: SearchSystem 
    {
        public Result search( Criteria c ) 
        {
            throw new ApplicationException("Criteria not foud", c );
        }
        Result doSearch( Criteria c )
        {
           // didn't we throw exception already?
        }
    }
