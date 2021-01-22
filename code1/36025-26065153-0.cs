    using System;
    namespace MyNameSpace
    {
        public class DomainEntity
        {
            public virtual int Id { get; set; }
            public override bool Equals(object other)
            {
                return Equals(other as DomainEntity);
            }
            public virtual bool Equals(DomainEntity other)
            {
                if (other == null) { return false; }
                if (object.ReferenceEquals(this, other)) { return true; }
                return this.Id == other.Id;
            }
            public override int GetHashCode()
            {
                return this.Id;
            }
            public static bool operator ==(DomainEntity item1, DomainEntity item2)
            {
                if (object.ReferenceEquals(item1, item2)) { return true; }
                if ((object)item1 == null || (object)item2 == null) { return false; }
                return item1.Id == item2.Id;
            }
            public static bool operator !=(DomainEntity item1, DomainEntity item2)
            {
                return !(item1 == item2);
            }
        }
    }
