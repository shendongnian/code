public class Base : IEquatable<Base>, IImmutable
{
    public readonly ImmutableType1 X;
    readonly ImmutableType2 Y;
    public Base(ImmutableType1 X, ImmutableType2 Y)
        => (this.X, this.Y) = (X, Y);
    protected int? hashCache;
    public override int GetHashCode()
    {
        if (hashCache is null)
            hashCache = GetHashTuple().GetHashCode();
        return hashCache.Value;
    }
    protected virtual IStructuralEquatable GetHashTuple()
        => (X, Y);
    protected virtual bool CompareValues(object obj)
        => obj is Base o 
           && (X, Y) == (o.X, o.Y);
    // boilerplate
    protected bool IsEqual(object obj) => ReferenceEquals(this, obj) || !(obj is null) && GetType() == obj.GetType() && GetHashCode()==obj.GetHashCode() && CompareValues(obj);
    public bool Equals(Base o) => IsEqual(o);
    public override bool Equals(object o) => IsEqual(o);
    public static bool operator ==(Base o1, Base o2) => o1.IsEqual(o2);
    public static bool operator !=(Base o1, Base o2) => !o1.IsEqual(o2);
}
public class Derived : Base, IEquatable<Derived>, IImmutable
{
    public readonly ImmutableType3 Z;
    readonly ImmutableType4 K;
    public Derived(ImmutableType1 X, ImmutableType2 Y, ImmutableType3 Z, ImmutableType4 K)
        : base(X, Y)
        => (this.Z, this.K) = (Z, K);
    protected override IStructuralEquatable GetHashTuple()
        => (K, Z, base.GetHashTuple());
    protected override bool CompareValues(object obj)
        => obj is Derived o
           && base.CompareValues(obj);
           && (K, Z) == (o.K, o.Z);
    // boilerplate
    public bool Equals(Derived o) => IsEqual(o);
}
