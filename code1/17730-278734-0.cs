    public void someMethod( object parm2, ArrayList parm3 )
    { 
      someMethod( null, parm2, parm3 );
    }
    public void someMethod( string parm1, ArrayList parm3 )
    {
      someMethod( parm1, null, parm3 );
    }
    public void someMethod( string parm1, object parm2, )
    {
      someMethod( parm1, parm2, null );
    }
    public void someMethod( string parm1 )
    {
      someMethod( parm1, null, null );
    }
    public void someMethod( object parm2 )
    {
      someMethod( null, parm2, null );
    }
    public void someMethod( ArrayList parm3 )
    {
      someMethod( null, null, parm3 );
    }
    public void someMethod( string parm1, object parm2, ArrayList parm3 )
    {
      // Set your default parameters here rather than scattered through the above function overloads
      parm1 = parm1 ?? "Default User Name";
      parm2 = parm2 ?? GetCurrentUserObj();
      parm3 = parm3 ?? DefaultCustomerList;
      // Do the rest of the stuff here
    }
