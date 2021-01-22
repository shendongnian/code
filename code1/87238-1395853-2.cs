public class KeyComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y)
    {
        return x.Replace(".", "") == y.Replace(".", "");
    }
    public int GetHashCode(string obj)
    {
        return obj.Replace(".", "").GetHashCode();
    }
}
