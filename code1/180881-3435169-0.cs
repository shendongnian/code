     public class MyClass
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
    
        }
    
        public class MyClassComparer : EqualityComparer<MyClass>
        {
            public override bool Equals(MyClass x, MyClass y)
            {
                return x != null && y != null && x.Property1 == y.Property1 && x.Property2 == y.Property2;
            }
    
            public override int GetHashCode(MyClass obj)
            {
                return obj == null ? 0 : (obj.Property1.GetHashCode() ^ obj.Property2.GetHashCode());
            }
        }
