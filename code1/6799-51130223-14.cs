      class MyClass : IEquatable<MyClass> {
        public int X { get; }
        public int Y { get; }
        public MyClass(int X, int Y) { this.X = X; this.Y = Y; }
    
        public override bool Equals(object obj) { var o = obj as MyClass; return o is null ? false : X.Equals(o.X) && Y.Equals(o.Y); }
        public bool Equals(MyClass o) => object.Equals(this, o);
        public static bool operator ==(MyClass o1, MyClass o2) => object.Equals(o1, o2);
        public static bool operator !=(MyClass o1, MyClass o2) => !object.Equals(o1, o2);
    
        public override int GetHashCode() => HashCode.Combine(X, Y);
      }
