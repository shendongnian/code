    public class CurrencyDetail : IEquatable<CurrencyDetail>
    {
        public string ISOName { get; set; }
        public string ISOCode { get; set; }
        public override bool Equals(object obj)
        {
            // obj is object, so we can use its == operator
            if (obj == null)
            {
                return false;
            }
            CurrencyDetail other = obj as CurrencyDetail;
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.InnerEquals(other);
        }
        public bool Equals(CurrencyDetail other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.InnerEquals(other);
        }
        private bool InnerEquals(CurrencyDetail other)
        {
            // Here we know that other != null;
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return this.ISOName == other.ISOName && this.ISOCode == other.ISOCode;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                // From http://stackoverflow.com/a/263416/613130
                int hash = 17;
                hash = hash * 23 + (this.ISOName != null ? this.ISOName.GetHashCode() : 0);
                hash = hash * 23 + (this.ISOCode != null ? this.ISOCode.GetHashCode() : 0);
                return hash;
            }
        }
    }
