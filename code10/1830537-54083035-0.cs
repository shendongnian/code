    usage: ReflectionHelper<MyClass>.GetPath(x => x.Foo.Blah) // -> "MyClass.Foo.Blah"
    public class ReflectionHelper<T>
    {
    	public static string GetPath<TProperty>(Expression<Func<T, TProperty>> expr)
    	{
    		var name = expr.Parameters[0].Name;
    
    		return expr.ToString()
    			.Replace($"{name} => {name}", typeof(T).Name);
    	}
    }
