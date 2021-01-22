public class DataClass
{
	public int SomeProp { get; set; }
	public DataClass(int value) => SomeProp = value;
}
The universal accessor class, where T1 is the type of class that contains a property and T2 is the type of that property looks like this:
public class PropAccessor<T1, T2>
{
	public readonly Func<T1, T2> Get;
	public readonly Action<T1, T2> Set;
	public PropAccessor(string propName)
	{
		Type t = typeof(T1);
		MethodInfo getter = t.GetMethod("get_" + propName);
		MethodInfo setter = t.GetMethod("set_" + propName);
		Get = (Func<T1, T2>)Delegate.CreateDelegate(typeof(Func<T1, T2>), null, getter);
		Set = (Action<T1, T2>)Delegate.CreateDelegate(typeof(Action<T1, T2>), null, setter);
	}
}
And then you can do:
var data = new DataClass(100);
var accessor = new PropAccessor<DataClass, int>("SomeProp");
log(accessor.Get(data));
accessor.Set(data, 200);
log(accessor.Get(data));
Basically, you can traverse your classes with reflection at startup and make a cache of PropAccessors for each property, giving you reasonably fast access.
Edit: a few more hours later..
Ended up with something like this. The abstract ancestor to PropAccessor was necessary, so that I could actually declare a field of that type in the Prop class, without resorting to use of dynamic. Ended up approximately 10x faster than with MethodInfo.Invoke for getters and setters.
internal abstract class Accessor
{
    public abstract void MakeAccessors(PropertyInfo pi);
    public abstract object Get(object obj);
    public abstract void Set(object obj, object value);
}
internal class PropAccessor<T1, T2> : Accessor
{
    private Func<T1, T2>    _get;
    private Action<T1, T2>  _set;
    public override object Get(object obj) => _get((T1)obj);
    public override void Set(object obj, object value) => _set((T1)obj, (T2)value);
    public PropAccessor() { }
    public override void MakeAccessors(PropertyInfo pi)
    {
        _get = (Func<T1, T2>)Delegate.CreateDelegate(typeof(Func<T1, T2>), null, pi.GetMethod);
        _set = (Action<T1, T2>)Delegate.CreateDelegate(typeof(Action<T1, T2>), null, pi.SetMethod);
    }
}
internal class Prop
{
    public string name;
    public int length;
    public int offset;
    public PropType type;
    public Accessor accessor;
}
internal class PropMap
{
    public UInt16 length;
    public List<Prop> props;
    internal PropMap()
    {
        length = 0;
        props = new List<Prop>();
    }
    internal Prop Add(PropType propType, UInt16 size, PropertyInfo propInfo)
    {
        Prop p = new Prop()
        {
            name   = propInfo.Name,
            length = size,
            offset = this.length,
            type   = propType,
            Encode = encoder,
            Decode = decoder,
        };
        Type accessorType = typeof(PropAccessor<,>).MakeGenericType(propInfo.DeclaringType, propInfo.PropertyType);
        p.accessor = (Accessor)Activator.CreateInstance(accessorType);
        p.accessor.MakeAccessors(propInfo);
        this.length += size;
        props.Add(p);
        return p;
    }
}
