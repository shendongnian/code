    public ActionResult Details( int id )
    {
        if( IdNeedsManipulation( id ) )
            id = ManipulateId( id );
    
        return View( id );
    }
    
    private int ManipulateId( int id )
    {
        // Do something to id
        return id;
    }
    private bool IdNeedsManipulation( int id ) { return ...; }
