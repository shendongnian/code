    class MyDerived : MyClass, IEquatable<MyDerived> {
      public int Z { get; }
      public int K { get; }
      public MyDerived(int x = 0, int y = 0, int z=0, int k=0) : base(x, y) { Z = z; K = k; }
    
      public override bool Equals(object obj) {
        var other = obj as MyDerived;
        return other is null ? false : base.Equals((object)other) && Z == other.Z && K == other.K;
      }
      public bool Equals(MyDerived other) => Equals((object)other);
      public static bool operator ==(MyDerived o1, MyDerived o2) => object.Equals(o1, o2);
      public static bool operator !=(MyDerived o1, MyDerived o2) => !(o1 == o2);
    
      public override int GetHashCode() => base.GetHashCode() ^ Z ^ K;
    }
