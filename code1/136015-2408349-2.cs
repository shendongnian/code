public class DateAndHourStringComparer : IEqualityComparer<string>
{
    private readonly DateAndHourComparer dateComparer = new DateAndHourComparer();
    public bool Equals(string x, string y)
    {
        var xDate = DateTime.Parse(x);
        var yDate = DateTime.Parse(y);
        return dateComparer.Equals(xDate, yDate);
    }
    public int GetHashCode(string obj)
    {
        var date = DateTime.Parse(obj);
        return dateComparer.GetHashCode(date);
    }
}
