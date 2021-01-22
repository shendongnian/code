You'd basically need to use Reflection. Use Activator.CreateInstance or new T() (with appropriate new constraint on the generic type) if using generics, to construct your type and then call InvokeMember on the type, to set the property:
public static T CreateInstanceAndSetProperty<T>(string prop,string val) where T: new()
{
    Type type = typeof(T);
    T obj = new T();
    type.InvokeMember(prop, BindingFlags.SetProperty, null, obj, new object[] { val });
    return obj;
}
