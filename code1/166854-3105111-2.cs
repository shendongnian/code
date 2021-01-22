    class EmailAddress
    {
        public string Address { get; set; }
        public override bool Equals( object o )
        {
            EmailAddress toCheck = o as EmailAddress;
            if( toCheck == null ) return false;
            // obviously this is a bit contrived, but you get the idea
            return ( this.Address == toCheck.Address );
        }
    }
