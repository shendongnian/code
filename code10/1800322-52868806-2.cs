    public abstract class DomainEntityIntPK
    {
        public int Id { get; set; }
    
        public static bool operator ==( DomainEntityIntPK lhs, DomainEntityIntPK rhs )
        {
            return Equals( lhs, rhs );
        }
    
        public static bool operator !=( DomainEntityIntPK lhs, DomainEntityIntPK rhs )
        {
            return !Equals( lhs, rhs );
        }
    
        public override Boolean Equals( object obj )
        {
            DomainEntityIntPK other = obj as DomainEntityIntPK;
            if( other == null ) return false;
    
            Boolean thisIsNew = Id == 0;
            Boolean otherIsNew = other.Id == 0;
            if( thisIsNew && otherIsNew )
            {
                Boolean referenceEquals =  ReferenceEquals( this, other );
                return referenceEquals;
            }
    
            Boolean idEquals = Id.Equals( other.Id );
            return idEquals;
        }
    }
