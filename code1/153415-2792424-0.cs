    public sealed class ItemEqualityComparer : EqualityComparer<Item>
    {
        public override bool Equals(Item x, Item y)
        {
            return x.Name.CompareTo(y.Name) == 0;
        }
    
        public override int GetHashCode(Item obj)
        {
            return obj.Name.GetHashCode();
        }
    }
