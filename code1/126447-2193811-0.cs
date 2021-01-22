    class MyTypeEqualityComparer : IEqualityComparer<MyType> {
        public bool Equals(MyType x, MyType y) {
            return x.Id.Equals(y.Id);
        }
        public int GetHashCode(MyType obj) {
            return obj.Id.GetHashCode();
        }
    }
