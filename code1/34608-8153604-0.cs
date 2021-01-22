    public override bool Equals(object obj)
        {
            Person p = obj as Person;
            if ( obj == null )
                return false;
            if ( object.ReferenceEquals( p , this ) )
                return true;
            if ( p.Age == this.Age && p.Name == this.Name && p.IsEgyptian == this.IsEgyptian )
                return true;
            return false;
            //return base.Equals( obj );
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
 
