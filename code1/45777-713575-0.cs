    [CompilerGenerated, DebuggerDisplay(@"\{ Name = {Name}, Location = {Location}, Sector = {Sector} }", Type="<Anonymous Type>")]
    internal sealed class <>f__AnonymousType0<<Name>j__TPar, <Location>j__TPar, <Sector>j__TPar>
    {
        // Fields
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly <Location>j__TPar <Location>i__Field;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly <Name>j__TPar <Name>i__Field;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly <Sector>j__TPar <Sector>i__Field;
    
        // Methods
        [DebuggerHidden]
        public <>f__AnonymousType0(<Name>j__TPar Name, <Location>j__TPar Location, <Sector>j__TPar Sector)
        {
            this.<Name>i__Field = Name;
            this.<Location>i__Field = Location;
            this.<Sector>i__Field = Sector;
        }
    
        [DebuggerHidden]
        public override bool Equals(object value)
        {
            var type = value as <>f__AnonymousType0<<Name>j__TPar, <Location>j__TPar, <Sector>j__TPar>;
            return ((((type != null) && EqualityComparer<<Name>j__TPar>.Default.Equals(this.<Name>i__Field, type.<Name>i__Field)) && EqualityComparer<<Location>j__TPar>.Default.Equals(this.<Location>i__Field, type.<Location>i__Field)) && EqualityComparer<<Sector>j__TPar>.Default.Equals(this.<Sector>i__Field, type.<Sector>i__Field));
        }
    
        [DebuggerHidden]
        public override int GetHashCode()
        {
            int num = 0x5fabc4ba;
            num = (-1521134295 * num) + EqualityComparer<<Name>j__TPar>.Default.GetHashCode(this.<Name>i__Field);
            num = (-1521134295 * num) + EqualityComparer<<Location>j__TPar>.Default.GetHashCode(this.<Location>i__Field);
            return ((-1521134295 * num) + EqualityComparer<<Sector>j__TPar>.Default.GetHashCode(this.<Sector>i__Field));
        }
    
        [DebuggerHidden]
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{ Name = ");
            builder.Append(this.<Name>i__Field);
            builder.Append(", Location = ");
            builder.Append(this.<Location>i__Field);
            builder.Append(", Sector = ");
            builder.Append(this.<Sector>i__Field);
            builder.Append(" }");
            return builder.ToString();
        }
    
        // Properties
        public <Location>j__TPar Location
        {
            get
            {
                return this.<Location>i__Field;
            }
        }
    
        public <Name>j__TPar Name
        {
            get
            {
                return this.<Name>i__Field;
            }
        }
    
        public <Sector>j__TPar Sector
        {
            get
            {
                return this.<Sector>i__Field;
            }
        }
    }
