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
            hashCache = GetValueTuple().GetHashCode();
        return hashCache.Value;
    }
    protected bool ImmutableEquals(object obj)
    {
        return ReferenceEquals(this, obj)
            || !(obj is null)
            && GetType() == obj.GetType()
            && GetHashCode() == obj.GetHashCode()
            && ValuesEqual(obj);
    }
    protected virtual IStructuralEquatable GetValueTuple()
        => (X, Y);
    protected virtual bool ValuesEqual(object obj)
        => obj is Base o2 && X == o2.X && Y == o2.Y;
    // Interface IEquatable
    public bool Equals(Base o) => this.ImmutableEquals(o);
    // Boilerplate
    public override bool Equals(object o) => this.ImmutableEquals(o);
    public static bool operator ==(Base o1, Base o2) => o1.ImmutableEquals(o2);
    public static bool operator !=(Base o1, Base o2) => !o1.ImmutableEquals(o2);
}
public class Derived : Base, IEquatable<Derived>, IImmutable
{
    public readonly ImmutableType3 Z;
    readonly ImmutableType4 K;
    public Derived(ImmutableType1 X, ImmutableType2 Y, ImmutableType3 Z, ImmutableType4 K)
        : base(X, Y)
        => (this.Z, this.K) = (Z, K);
    protected override IStructuralEquatable GetValueTuple()
        => (K, Z, base.GetValueTuple());
    protected override bool ValuesEqual(object obj)
        => obj is Derived o2 && K == o2.K && Z == o2.Z && base.ValuesEqual(obj);
    // Interface IEquatable
    public bool Equals(Derived o) => this.ImmutableEquals(o);
}
