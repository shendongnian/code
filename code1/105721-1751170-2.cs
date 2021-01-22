InstantiateMe me = CreateInstanceAndSetProperty<InstantiateMe>("foo", "bar");
string fooProperty = me.foo;
To access all the properties of the generic type and set / get them, you can use GetProperties() which returns a PropertyInfo collection:
public static void CreateInstanceAndDoSomethingWithProperties<T>() where T: new()
{
    Type type = typeof(T);
    T obj = new T();
    foreach (PropertyInfo propInf in type.GetProperties())
    { 
        // use propInf.GetValue() and propInf.SetValue() overloads to get set property
    }    
}
Also, see [the docs][1] for more ways of using InvokeMember().
