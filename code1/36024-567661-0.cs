    public override bool Equals ( object obj )
    {
       // struct
       return obj  is Point2 && Equals (  ( Point2 ) value );
       // class
       //return Equals ( obj as Point2 );
    }
    
    public bool Equals ( Point2 obj )
