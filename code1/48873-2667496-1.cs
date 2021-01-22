public static Vector4&lt;T&gt; operator +(Vector4&lt;T&gt; a, Vector4&lt;T&gt; b)
{
    Vector4&lt;Decimal&gt; A = a;
    Vector4&lt;Decimal&gt; B = b;
    var result = new Vector4&lt;Decimal&gt;(A.X + B.X, A.Y + B.Y, A.Z + B.Z, A.W + B.W);
    return result;
}
public static implicit operator Vector4&lt;Decimal&gt;(Vector4&lt;T&gt; v)
{
    return new Vector4&lt;Decimal&gt;(
        Convert.ToDecimal(v.X), 
        Convert.ToDecimal(v.Y), 
        Convert.ToDecimal(v.Z), 
        Convert.ToDecimal(v.W));
}
public static implicit operator Vector4&lt;T&gt;(Vector4&lt;Decimal&gt; v)
{
    return new Vector4&lt;T&gt;(
        (T)Convert.ChangeType(v.X, typeof(T)), 
        (T)Convert.ChangeType(v.Y, typeof(T)), 
        (T)Convert.ChangeType(v.Z, typeof(T)), 
        (T)Convert.ChangeType(v.W, typeof(T)));
}
