    public struct EmailAddress : IEquatable<EmailAddress>
    {
        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == typeof(EmailAddress) && Equals((EmailAddress)obj);
        }
    
        public bool Equals(EmailAddress other)
        {
            return this.LocalPart == other.LocalPart && this.Domain == other.Domain;
        }
    }
