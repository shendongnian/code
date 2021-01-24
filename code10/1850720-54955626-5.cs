public class Base : IEquatable<Base>, IImmutable
{
    public readonly ImmutableType1 X;
    readonly ImmutableType2 Y;
    public Base(ImmutableType1 X, ImmutableType2 Y) => (this.X, this.Y) = (X, Y);
    // boilerplate
    public override bool Equals(object obj) => this.ImmutableEquals(obj);
    public bool Equals(Base o) => this.ImmutableEquals(o);
    public static bool operator ==(Base o1, Base o2) => o1.ImmutableEquals(o2);
    public static bool operator !=(Base o1, Base o2) => !o1.ImmutableEquals(o2);
    private int? _hashCache;
    public override int GetHashCode() => this.ImmutableHash(ref _hashCache);
}
public class Derived : Base, IEquatable<Derived>, IImmutable
{
    public readonly ImmutableType3 Z;
    readonly ImmutableType4 K;
    public Derived(ImmutableType1 X, ImmutableType2 Y, ImmutableType3 Z, ImmutableType4 K) : base(X, Y) => (this.Z, this.K) = (Z, K);
    public bool Equals(Derived other) => this.ImmutableEquals(other);
}
And the `IImmutableExtensions` class:
public static class IImmutableExtensions
{
    public static bool ImmutableEquals(this IImmutable o1, object o2)
    {
        if (ReferenceEquals(o1, o2)) return true;
        if (o2 is null || o1.GetType() != o2.GetType() || o1.GetHashCode() != o2.GetHashCode()) return false;
        foreach (var tProp in GetImmutableFields(o1))
        {
            var test = tProp.GetValue(o1)?.Equals(tProp.GetValue(o2));
            if (test is null) continue;
            if (!test.Value) return false;
        }
        return true;
    }
    public static int ImmutableHash(this IImmutable o, ref int? hashCache)
    {
        if (hashCache is null)
        {
            hashCache = 0;
            foreach (var tProp in GetImmutableFields(o))
            {
                hashCache = HashCode.Combine(hashCache.Value, tProp.GetValue(o).GetHashCode());
            }
        }
        return hashCache.Value;
    }
    private static IEnumerable<FieldInfo> GetImmutableFields(object o)
    {
        var t = o.GetType();
        do
        {
            var fields = t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Where(field => field.IsInitOnly);
            foreach(var field in fields)
            {
                yield return field;
            }
        }
        while ((t = t.BaseType) != typeof(object));
    }
}
Old answer: (I will leave this for reference)
Based on what you were saying about having to cast to `object` it occurred to me that the methods `Equals(object)` and `Equals(Base)` were too ambiguous when calling them from a derived class.
This said to me that the logic should be moved out of both of the classes, to a method that would better describe our intentions.
Equality will remain polymorphic as `ImmutableEquals` in the base class will call the overridden `ValuesEqual`. This is where you can decide in each derived class how to compare equality.
This is your code refactored with that goal.
Revised answer:
It occurred to me that all of our logic in `IsEqual()` and `GetHashCode()` would work if we simply supplied a tuple that contained the immutable fields that we wanted to compare. This avoids duplicating so much code in every class.
It is up to the developer that creates the derived class to override `GetImmutableTuple()`. Without using reflection (see other answer), I feel this is the least of all evils.
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
