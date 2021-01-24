    internal class Key
    {
        public readonly bool IsNetworkDeployed { get; }
        public readonly InventoryTypeEnum InventoryType { get; }
        public Key(InventoryTypeEnum inventoryType, bool isNetworkDeployed=false)
        {
            IsNetworkDeployed = isNetworkDeployed;
            InventoryType = inventoryType;
        }
        protected bool Equals(Key other)
        {
            return IsNetworkDeployed == other.IsNetworkDeployed && 
                   InventoryType == other.InventoryType;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Key) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (IsNetworkDeployed.GetHashCode() * 397) ^ (int) InventoryType;
            }
        }
    }
