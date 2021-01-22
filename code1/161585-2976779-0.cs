public abstract class MyObjectB<T>
{
    public T Value
    {
        get;
        set;
    }
    public MyObjectB(T _value)
    {
        Value = _value;
    }
}
