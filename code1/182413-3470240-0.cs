    public static bool operator ==(MyType left, MyType right)
    {
        //code here, don't forget about NULLS when writing comparison code!!!
    }
    public static bool operator !=(MyType left, MyType right)
    {
        return !(left == right);
    }
    public bool Equals(MyType x, MyType y)
    {
        return (x == y);
    }
    public int GetHashCode(MyType obj)
    {
        return base.GetHashCode();
    }
