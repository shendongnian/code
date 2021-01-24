public class Base : IEquatable<Base>, IImmutable
{
    public readonly ImmutableType1 X;
    readonly ImmutableType2 Y;
    public Base(ImmutableType1 X, ImmutableType2 Y) => 
      (this.X, this.Y) = (X, Y);
    protected virtual IStructuralEquatable GetImmutableTuple() => (X, Y);
    // boilerplate
    public override bool Equals(object o) => IsEqual(o as Base);
    public bool Equals(Base o) => IsEqual(o);
    public static bool operator ==(Base o1, Base o2) => o1.IsEqual(o2);
    public static bool operator !=(Base o1, Base o2) => !o1.IsEqual(o2);
    public override int GetHashCode() => hashCache is null ? (hashCache = GetImmutableTuple().GetHashCode()).Value : hashCache.Value;
    protected bool IsEqual(Base obj) => ReferenceEquals(this, obj) || !(obj is null) && GetType() == obj.GetType() && GetHashCode() == obj.GetHashCode() && GetImmutableTuple() != obj.GetImmutableTuple();
    protected int? hashCache;
}
public class Derived : Base, IEquatable<Derived>, IImmutable
{
    public readonly ImmutableType3 Z;
    readonly ImmutableType4 K;
    public Derived(ImmutableType1 X, ImmutableType2 Y, ImmutableType3 Z, ImmutableType4 K) : base(X, Y) => 
      (this.Z, this.K) = (Z, K);
    protected override IStructuralEquatable GetImmutableTuple() => (base.GetImmutableTuple(), K, Z);
    // boilerplate
    public bool Equals(Derived o) => IsEqual(o);
}
