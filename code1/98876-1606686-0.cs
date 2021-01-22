    class DistinctItemComparer : IEqualityComparer<Item> {
        public bool Equals(Item x, Item y) {
            return x.Id == y.Id &&
                x.Name == y.Name &&
                x.Code == y.Code &&
                x.Price == y.Price;
        }
        public int GetHashCode(Item obj) {
            return obj.Id.GetHashCode() ^
                obj.Name.GetHashCode() ^
                obj.Code.GetHashCode() ^
                obj.Price.GetHashCode();
        }
    }
