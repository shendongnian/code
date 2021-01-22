    struct Bar
    { 
       public int Val;  
       public Bar( int v ) { Val = v; }
       public static implicit operator Bar( int v )
       {
           return new Bar( v );
       }
    }
    // array of structs initialized using user-defined implicit converions...
    Bar[] evenMoreBars = new Bar[] { 1, 2, 3, 4, 5 };
