public class Base : Comparable, IEquatable<Base>, IImmutable
{
    [Compare]
    public ImmutableType1 X { get; set; }
    [Compare]
    readonly ImmutableType2 Y;
    public Base(ImmutableType1 X, ImmutableType2 Y) => (this.X, this.Y) = (X, Y);
    public bool Equals(Base o) => AutoCompare(o);
}
public class Derived : Base, IEquatable<Derived>, IImmutable
{
    [Compare]
    public readonly ImmutableType3 Z;
    [Compare]
    readonly ImmutableType4 K;
    public Derived(ImmutableType1 X, ImmutableType2 Y, ImmutableType3 Z, ImmutableType4 K)
        : base(X, Y)
        => (this.Z, this.K) = (Z, K);
    public bool Equals(Derived o) => AutoCompare(o);
}
[AttributeUsage(validOn: AttributeTargets.Field | AttributeTargets.Property)]
public class CompareAttribute : Attribute { }
public abstract class Comparable
{
    static BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;
    protected int? hashCache;
    public override int GetHashCode()
    {
        if (hashCache is null)
        {
            hashCache = 0;
            var type = GetType();
            do
            {
                foreach (var field in type.GetFields(flags).Where(field => Attribute.IsDefined(field, typeof(CompareAttribute))))
                    hashCache = HashCode.Combine(hashCache, field.GetValue(this));
                foreach (var property in type.GetProperties(flags).Where(property => Attribute.IsDefined(property, typeof(CompareAttribute))))
                    hashCache = HashCode.Combine(hashCache, property.GetValue(this));
                type = type.BaseType;
            }
            while (type != null);
        }
        return hashCache.Value;
    }
    protected bool AutoCompare(object obj2)
    {
        if (ReferenceEquals(this, obj2)) return true;
        if (obj2 is null
            || GetType() != obj2.GetType()
            || GetHashCode() != obj2.GetHashCode())
            return false;
        var type = GetType();
        do
        {
            foreach (var field in type.GetFields(flags).Where(field => Attribute.IsDefined(field, typeof(CompareAttribute))))
            {
                if (field.GetValue(this) != field.GetValue(obj2))
                {
                    return false;
                }
            }
            foreach (var property in type.GetProperties(flags).Where(property => Attribute.IsDefined(property, typeof(CompareAttribute))))
            {
                if (property.GetValue(this) != property.GetValue(obj2))
                {
                    return false;
                }
            }
            type = type.BaseType;
        }
        while (type != null);
        return true;
    }
    public override bool Equals(object o) => AutoCompare(o);
    public static bool operator ==(ComparableImmutable o1, ComparableImmutable o2) => o1.AutoCompare(o2);
    public static bool operator !=(ComparableImmutable o1, ComparableImmutable o2) => !o1.AutoCompare(o2);
}
