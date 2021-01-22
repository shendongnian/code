c#
public class RangeLimit<T> where T : IComparable<T>
{
    public T Min { get; }
    public T Max { get; }
    public RangeLimit(T min, T max)
    {
        if (min.CompareTo(max) > 0)
            throw new InvalidOperationException("invalid range");
        Min = min;
        Max = max;
    }
    public void Validate(T param)
    {
        if (param.CompareTo(Min) < 0 || param.CompareTo(Max) > 0)
            throw new InvalidOperationException("invalid argument");
    }
    public T Clamp(T param) => param.CompareTo(Min) < 0 ? Min : param.CompareTo(Max) > 0 ? Max : param;
}
The class works for all object which are `IComparable`. I create an instance with a certain range:
c#
RangeLimit<int> range = new RangeLimit<int>(0, 100);
I an either validate an argument
c#
range.Validate(value);
or clamp the argument to the range:
c#
var v = range.Validate(value);
