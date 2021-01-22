    using System;
    ...
    public override bool Equals ( object obj ) {
       return Equals(obj as SomeClass);
    }
    public bool Equals ( SomeClass someInstance ) {
        return Object.ReferenceEquals( this, someInstance ) 
            || ( !Object.ReferenceEquals( someInstance, null ) 
                && this.Value == someInstance.Value );
    }
    public static bool operator ==( SomeClass lhs, SomeClass rhs ) {
        if( Object.ReferenceEquals( lhs, null ) ) {
            return Object.ReferenceEquals( rhs, null );
        }
        return lhs.Equals( rhs );
        //OR
        return Object.ReferenceEquals( lhs, rhs )
                || ( !Object.ReferenceEquals( lhs, null ) 
                    && !Object.ReferenceEquals( rhs, null )
                    && lhs.Value == rhs.Value );
    }
    public static bool operator !=( SomeClass lhs, SomeClass rhs ) {
        return !( lhs == rhs );
        // OR
        return ( Object.ReferenceEquals( lhs, null ) || !lhs.Equals( rhs ) )
                && !Object.ReferenceEquals( lhs, rhs );
    }
