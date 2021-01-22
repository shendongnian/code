    public struct Account : IEquatable<Account>
    {
        public int Id;
        public double Amount;
    
        public bool Equals(Account other)
        {
            if (other == null) return false;
            return (this.Id.Equals(other.Id));
        }
    }
