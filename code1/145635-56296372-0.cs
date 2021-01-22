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
