csharp
public override int GetHashCode()
{
    unchecked
    {
        var hashCode = -504981047;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Foo);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Bar);
        return hashCode;
    }
}
