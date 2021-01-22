      class MyDerived : MyClass, IEquatable<MyDerived> {
        public int Z { get; }
        public int K { get; }
        public MyDerived(int X, int Y, int Z, int K) : base(X, Y) { this.Z = Z; this.K = K; }
    
        public override bool Equals(object obj) { 
          var o = obj as MyDerived; 
          return o is null ? false : base.Equals(obj) && Z.Equals(o.Z) && K.Equals(o.K); 
        }
        public bool Equals(MyDerived o) => object.Equals(this, o);
        public static bool operator ==(MyDerived o1, MyDerived o2) => object.Equals(o1, o2);
        public static bool operator !=(MyDerived o1, MyDerived o2) => !object.Equals(o1, o2);
    
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Z, K);
      }
